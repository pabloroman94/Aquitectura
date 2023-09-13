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
    public class CompanyContactPerson : CrudStampController<Domain.Entities.CompanyContactPerson, Guid, CompanyContactPersonModel, CompanyContactPersonFilter>
    {
        public CompanyContactPerson(IMapper mapper, IBaseStampAplication<Domain.Entities.CompanyContactPerson, Guid, CompanyContactPersonFilter> aplicacion, IUriService uriService, IOptions<PaginationOptions> options, ILogger<Domain.Entities.CompanyContactPerson> logger = null) : base(mapper, aplicacion, uriService, options, logger)
        {
        }
    }
}
