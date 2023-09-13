using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Primitives;
using Serilog.Context;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Customer.Api.Middlewares
{
    public class CorrelationIdMiddleware
    {
        private const string CorrelationIdHeaderKey = "X-Correlation-Id";
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;
        public CorrelationIdMiddleware(RequestDelegate next, Microsoft.Extensions.Logging.ILoggerFactory loggerFactory)
        {
            _next = next ?? throw new ArgumentNullException(nameof(next));
            _logger = loggerFactory.CreateLogger<CorrelationIdMiddleware>();
        }
        public async Task Invoke(HttpContext httpContext)
        {
            string correlationId = null;
            if (httpContext.Request.Headers.TryGetValue(CorrelationIdHeaderKey, out StringValues correlationIds))
            {
                correlationId = correlationIds.FirstOrDefault();
                _logger.LogInformation($"CorrelationId from Request Header: { correlationId} ");
            }
            else
            {
                correlationId = Guid.NewGuid().ToString();
                httpContext.Request.Headers.Add(CorrelationIdHeaderKey, correlationId);
                _logger.LogInformation($"Generated CorrelationId: { correlationId} ");
            }
            httpContext.Response.OnStarting(() =>
            {
                if (!httpContext.Response.Headers.TryGetValue(CorrelationIdHeaderKey, out correlationIds))
                    httpContext.Response.Headers.Add(CorrelationIdHeaderKey, correlationId);
                return Task.CompletedTask;
            });
            using (LogContext.PushProperty("CorrelationId", correlationId))
            {
                await _next.Invoke(httpContext);
            }
            //await _next.Invoke(httpContext);
        }

    }
}
