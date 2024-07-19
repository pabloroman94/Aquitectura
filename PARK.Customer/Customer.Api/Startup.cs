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
using Microsoft.EntityFrameworkCore;
using HealthChecks.MySql;
using Infrastructure.Data.EF;

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

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<LoggingDelegatingHandler>();
            services.AddControllers()
                .AddJsonOptions(c => c.JsonSerializerOptions.ReferenceHandler = null)
                .AddNewtonsoftJson(c => c.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore)
                .AddFluentValidation(c => c.RegisterValidatorsFromAssemblyContaining<Startup>());

            services.AddDbContext<Park_CustomerContext>(options =>
                options.UseMySql(Configuration.GetConnectionString("DefaultConnection"),
                new MySqlServerVersion(new Version(8, 0, 21))));

            services.AddModules(Configuration);
            services.AddAutoMapper(typeof(Startup));

            // CORS
            services.AddCors(options =>
            {
                options.AddPolicy(name: CORSPolicy,
                builder =>
                {
                    builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
                });
            });

            // API Versioning
            services.AddApiVersioning(config =>
            {
                config.ReportApiVersions = true;
                config.AssumeDefaultVersionWhenUnspecified = true;
                config.DefaultApiVersion = new ApiVersion(1, 0);
                config.ApiVersionReader = ApiVersionReader.Combine(new UrlSegmentApiVersionReader());
            });

            services.AddVersionedApiExplorer(options =>
            {
                options.GroupNameFormat = "'v'VVV";
                options.SubstituteApiVersionInUrl = true;
            });

            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();
            services.AddSwaggerGen(options =>
            {
                options.OperationFilter<SwaggerDefaultValues>();

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
                var accessor = provider.GetRequiredService<IHttpContextAccessor>();
                var request = accessor.HttpContext.Request;
                var absoluteUri = string.Concat(request.Scheme, "://", request.Host.ToUriComponent());
                return new UriService(absoluteUri);
            });

            services.Configure<PaginationOptions>(options => Configuration.GetSection("Pagination").Bind(options));

            services.AddHttpContextAccessor();

            // Configurar Health Checks para MySQL
            services.AddHealthChecks()
                .AddMySql(Configuration.GetConnectionString("DefaultConnection"), name: "mysql", failureStatus: HealthStatus.Unhealthy);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory, IApiVersionDescriptionProvider provider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();

            app.UseSwaggerUI(options =>
            {
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

            app.UseHealthChecks("/hc-details", new HealthCheckOptions
            {
                ResponseWriter = async (context, report) =>
                {
                    var result = JsonConvert.SerializeObject(new
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
