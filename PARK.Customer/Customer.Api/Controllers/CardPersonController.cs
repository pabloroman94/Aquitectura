using AutoMapper;
using Customer.Api.Models;
using Customer.Api.Models.Request;
using CustomerApp.Api.CustomEntities;
using CustomerApp.Api.Services;
using Domain.Entities;
using Domain.Entities.Filters;
using Domain.Interfaces.Aplication;
using Domain.Interfaces.Aplication.SeedWork;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using PARK.CustomerApi.Controllers;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Customer.Api.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class CardPersonController : CrudStampController<CardPersonResponse, UserPerson, Guid, UserPersonModel, UserPersonFilter>
    {
        private readonly IUserPersonAplication _userPersonAplication;

        public CardPersonController(IUserPersonAplication userPersonAplication, IMapper mapper, IBaseStampAplication<UserPerson, Guid, UserPersonFilter> aplicacion, IUriService uriService, IOptions<PaginationOptions> options, ILogger<UserPerson> logger = null) : base(mapper, aplicacion, uriService, options, logger)
        {
            this._userPersonAplication = userPersonAplication;
        }

        //[HttpPost("GetPersonsByFilter")]
        //public IEnumerable<UserPersonResponse> GetPersonsByFilter()
        //{
        //    var userPerson = _userPersonAplication.GetPersonsByFilter();
        //    var response = _mapper.Map<IEnumerable<UserPersonResponse>>(userPerson);
        //    return response;
        //}
        [HttpGet("GetCardPersons")]
        public IEnumerable<CardPersonResponse> GetCardPersons()
        {
            var userPerson = _userPersonAplication.GetPersonsByFilter();
            var response = _mapper.Map<IEnumerable<CardPersonResponse>>(userPerson);
            return response;
        }

    }
}
