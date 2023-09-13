using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using PARK.CustomerApi.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace PARK.CustomerApi.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next.Invoke(context);
            }

            catch (ApplicationException ex)
            {
                _logger.LogCritical(ex, "App error occurred.");
                await HandleException(context.Response, ex, HttpStatusCode.BadRequest, 1);
            }

            catch (Exception error)
            {
                var response = context.Response;

                switch (error)
                {
                    /*case AppException e:
                        // custom application error
                        response.StatusCode = (int)HttpStatusCode.BadRequest;
                        break;
                    */
                    case KeyNotFoundException e:
                        // not found error
                        response.StatusCode = (int)HttpStatusCode.NotFound;
                        break;
                    default:
                        // unhandled error
                        response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        break;
                }
                await HandleException(context.Response, error, response.StatusCode, 1);
            }
        }

        private async Task HandleException(HttpResponse response, Exception ex, HttpStatusCode statusCode, int codigoError)
        {
            _logger.LogError(ex, "An eRror occurred.");
            var responseModel = new ApiResponseModel<string>("", codigoError, ex.Message);

            var error = JsonConvert.SerializeObject(responseModel);

            response.StatusCode = (int)statusCode;
            response.ContentType = "application/json";
            await response.WriteAsync(error);
        }

        private async Task HandleException(HttpResponse response, Exception ex, int statusCode, int codigoError)
        {
            _logger.LogError(ex, "An eRror occurred.");
            var _detailError = (ex.InnerException != null ? ex.InnerException.ToString() : "");
            var responseModel = new ApiResponseModel<string>("", codigoError, (ex.Message + "(" + _detailError + ")"));

            var error = JsonConvert.SerializeObject(responseModel);

            response.StatusCode = (int)statusCode;
            response.ContentType = "application/json";
            await response.WriteAsync(error);
        }
    }
}
