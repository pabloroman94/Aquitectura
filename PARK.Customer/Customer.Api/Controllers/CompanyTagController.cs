using AutoMapper;
using Customer.Api.Models;
using Customer.Api.Models.Request;
using CustomerApp.Api.CustomEntities;
using CustomerApp.Api.Services;
using Domain.Entities;
using Domain.Entities.Filters;
using Domain.Interfaces.Aplication.SeedWork;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using PARK.CustomerApi.Controllers;
using System;

namespace Customer.Api.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class CompanyTagController : CrudStampController<TestResponse,CompanyTag, Guid, CompanyTagModel, CompanyTagFilter>
    {
        public CompanyTagController(IMapper mapper, IBaseStampAplication<CompanyTag, Guid, CompanyTagFilter> aplicacion, IUriService uriService, IOptions<PaginationOptions> options, ILogger<CompanyTag> logger = null) : base(mapper, aplicacion, uriService, options, logger)
        {
        }
    }
}
