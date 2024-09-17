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
    public class UserCategoryController : CrudStampController<TestResponse,UserCategory, Guid, UserCategoryModel, UserCategoryFilter>
    {
        public UserCategoryController(IMapper mapper, IBaseStampAplication<UserCategory, Guid, UserCategoryFilter> aplicacion, IUriService uriService, IOptions<PaginationOptions> options, ILogger<UserCategory> logger = null) : base(mapper, aplicacion, uriService, options, logger)
        {
        }
    }
}
