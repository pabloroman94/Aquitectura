using AutoMapper;
using Customer.Api.Models;
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
    public class GenderController : CrudStampController<Gender, Guid, GenderModel, GenderFilter>
    {
        public GenderController(IMapper mapper, IBaseStampAplication<Gender, Guid, GenderFilter> aplicacion, IUriService uriService, IOptions<PaginationOptions> options, ILogger<Gender> logger = null) : base(mapper, aplicacion, uriService, options, logger)
        {
        }
    }
}
