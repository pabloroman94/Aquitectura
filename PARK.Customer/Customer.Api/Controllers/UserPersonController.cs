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
    public class UserPersonController : CrudStampController<UserPersonResponse, UserPerson, Guid, UserPersonModel, UserPersonFilter>
    {
        private readonly IUserPersonAplication _userPersonAplication;

        public UserPersonController(IUserPersonAplication userPersonAplication, IMapper mapper, IBaseStampAplication<UserPerson, Guid, UserPersonFilter> aplicacion, IUriService uriService, IOptions<PaginationOptions> options, ILogger<UserPerson> logger = null) : base(mapper, aplicacion, uriService, options, logger)
        {
            this._userPersonAplication = userPersonAplication;
        }
        [HttpPost("CreatePerson2")]
        public async Task<UserPersonResponse> CreatePerson2(UserPersonRequest userPersonRequest)
        {
            var userPerson = _mapper.Map<UserPerson>(userPersonRequest);
            var person = await _userPersonAplication.CreatePerson(userPerson);
            var response = _mapper.Map<UserPersonResponse>(person);

            return response;
        }
        [HttpGet("GetAllPersons")]
        public IEnumerable<UserPersonResponse> GetAllPersons()
        {
            var userPerson = _userPersonAplication.GetAllPersons();
            var response = _mapper.Map<IEnumerable<UserPersonResponse>>(userPerson);
            return response;
        }
        [HttpGet("GetPersonById")]
        public UserPersonResponse GetPersonById(Guid id)
        {
            var userPerson = _userPersonAplication.GetPersonById(id);
            var response = _mapper.Map<UserPersonResponse>(userPerson);
            return response;
        }
    }
}
