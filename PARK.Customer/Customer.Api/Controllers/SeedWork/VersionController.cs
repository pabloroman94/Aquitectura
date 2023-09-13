using Customer.Api.Models.SeedWork;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Net;
using System.Reflection;

namespace Customer.Api.Controllers.SeedWork
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class VersionController : ControllerBase
    {
        private readonly IWebHostEnvironment _environment;

        public VersionController(IWebHostEnvironment environment)
        {
            this._environment = environment;
        }

        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public ActionResult<ApiInfo> Get()
        {
            var version = Assembly.GetExecutingAssembly().GetName().Version.ToString();
            var formattedVersion = version.Split(".").Take(3).Aggregate((i, j) => i + "." + j);

            ApiInfo apiInfo = new()
            {
                ApiName = _environment.ApplicationName,
                Version = formattedVersion,
                Environment = _environment.EnvironmentName
            };

            return Ok(apiInfo);
        }
    }
}

