using Eventual.Writer;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using PARK.CustomerApi.Middlewares;
using PARK.CustomerApi.Models;
using CustomerApp.Api.Configurations;
using CustomerApp.Api.CustomEntities;
using CustomerApp.Api.Services;
using Serilog;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Reflection;
using Customer.Infrastructure.Ioc;
using Customer.Api.Middlewares;

namespace PARK.CustomerApi
{
    public class Startup
    {
        readonly string CORSPolicy = "_CORSPolicy";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<LoggingDelegatingHandler>();
            services.AddControllers()
                .AddJsonOptions(c => c.JsonSerializerOptions.ReferenceHandler = null)
                .AddNewtonsoftJson(c => c.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore)
                .AddFluentValidation(c => c.RegisterValidatorsFromAssemblyContaining<Startup>());

            services.AddModules(Configuration);
            services.AddAutoMapper(typeof(Startup));

            //CORS
            services.AddCors(options =>
            {
                options.AddPolicy(name: CORSPolicy,
                builder =>
                {
                    builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
                });
            });


            services.AddApiVersioning(config =>
            {
                // Add the headers "api-supported-versions" and "api-deprecated-versions"
                // This is better for discoverability
                config.ReportApiVersions = true;

                // AssumeDefaultVersionWhenUnspecified should only be enabled when supporting legacy services that did not previously
                // support API versioning. Forcing existing clients to specify an explicit API version for an
                // existing service introduces a breaking change. Conceptually, clients in this situation are
                // bound to some API version of a service, but they don't know what it is and never explicit request it.
                config.AssumeDefaultVersionWhenUnspecified = true;
                config.DefaultApiVersion = new ApiVersion(1, 0);

                // Defines how an API version is read from the current HTTP request
                config.ApiVersionReader = ApiVersionReader.Combine(new UrlSegmentApiVersionReader());
            });

            services.AddVersionedApiExplorer(options =>
            {
                // add the versioned api explorer, which also adds IApiVersionDescriptionProvider service
                // note: the specified format code will format the version as "'v'major[.minor][-status]"
                options.GroupNameFormat = "'v'VVV";

                // note: this option is only necessary when versioning by url segment. the SubstitutionFormat
                // can also be used to control the format of the API version in route templates
                options.SubstituteApiVersionInUrl = true;
            });
            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();
            services.AddSwaggerGen(
                options =>
                {
                    options.OperationFilter<SwaggerDefaultValues>();

                    ///Agrego los comentarios
                    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                    options.IncludeXmlComments(xmlPath);

                });

            services.AddMvc().ConfigureApiBehaviorOptions(options =>
            {
                options.InvalidModelStateResponseFactory = c =>
                {
                    var errors = string.Join('\n', c.ModelState.Values.Where(v => v.Errors.Count > 0)
                      .SelectMany(v => v.Errors)
                      .Select(v => v.ErrorMessage));

                    var responseModel = new ApiResponseModel<string>("", 1, errors);
                    return new BadRequestObjectResult(responseModel);
                };
            });
            services.AddSingleton<IUriService>(provider =>
            {
                var accesor = provider.GetRequiredService<IHttpContextAccessor>();
                var request = accesor.HttpContext.Request;
                var absoluteUri = string.Concat(request.Scheme, "://", request.Host.ToUriComponent());
                return new UriService(absoluteUri);
            });

            services.Configure<PaginationOptions>(options => Configuration.GetSection("Pagination").Bind(options));

            services.AddHttpContextAccessor();
            services.AddHealthChecks()
                .AddOracle(Configuration.GetConnectionString("DefaultConnection"));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory, IApiVersionDescriptionProvider provider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwagger();
            //app.UseSwagger(options =>
            //{
            //    options.PreSerializeFilters.Add((swagger, httpReq) =>
            //    {
            //        if (httpReq.Headers.ContainsKey("X-Forwarded-Host"))
            //        {
            //            var basePath = Configuration.GetSection("Paths:BasePath").Value;
            //            var serverUrl = $"{httpReq.Scheme}://{httpReq.Headers["X-Forwarded-Host"]}/{basePath}";
            //            swagger.Servers = new List<OpenApiServer> { new OpenApiServer { Url = serverUrl } };
            //        }
            //    });
            //});
            app.UseSwaggerUI(
                    options =>
                    {
                        // build a swagger endpoint for each discovered API version
                        foreach (var description in provider.ApiVersionDescriptions)
                        {
                            options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant());
                        }
                    });

            app.UseMiddleware<CorrelationIdMiddleware>();
            app.UseMiddleware<ExceptionMiddleware>();          

            loggerFactory.AddSerilog();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(CORSPolicy);

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();

                endpoints.MapHealthChecks("/hc").RequireCors(CORSPolicy);
            });

            app.UseHealthChecks("/hc-details",
               new HealthCheckOptions
               {
                   ResponseWriter = async (context, report) =>
                   {
                       var result = JsonConvert.SerializeObject(
                           new
                           {
                               status = report.Status.ToString(),
                               errors = report.Entries.Select(e => new { key = e.Key, value = Enum.GetName(typeof(HealthStatus), e.Value.Status) })
                           });
                       context.Response.ContentType = MediaTypeNames.Application.Json;
                       await context.Response.WriteAsync(result);
                   }
               });
        }
    }
}