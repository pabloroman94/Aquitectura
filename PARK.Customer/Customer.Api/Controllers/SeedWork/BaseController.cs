using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace PARK.CustomerApi.Controllers
{
    public abstract class BaseController<TEntity> : ControllerBase
    {

        protected internal ILogger<TEntity> _logger;

        public BaseController(ILogger<TEntity> logger)
        {

            _logger = logger ?? throw new ArgumentNullException(nameof(ILogger<TEntity>));
        }

        protected string GenerateIPAddress()
        {
            if (this.Request.Headers.ContainsKey("X-Forwarded-For"))
            {
                return this.Request.Headers["X-Forwarded-For"];
            }
            else
            {
                return this.HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            }
        }
    }
}
