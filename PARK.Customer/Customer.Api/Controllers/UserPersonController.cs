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
using System.Threading.Tasks;

namespace Customer.Api.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class UserPersonController : CrudStampController<UserPerson, Guid, UserPersonModel, UserPersonFilter>
    {
        private readonly IUserPersonAplication _userPersonAplication;

        public UserPersonController(IUserPersonAplication userPersonAplication, IMapper mapper, IBaseStampAplication<UserPerson, Guid, UserPersonFilter> aplicacion, IUriService uriService, IOptions<PaginationOptions> options, ILogger<UserPerson> logger = null) : base(mapper, aplicacion, uriService, options, logger)
        {
            this._userPersonAplication = userPersonAplication;
        }
        [HttpPost("CreatePerson2")]
        public async Task<UserPerson> CreatePerson2(UserPersonRequest userPersonRequest)
        {
            //public class UserPersonRequest : UserRequest---->estoy mandando mal el objeto, hay que ver el mapper... llegar a la plataforma de aplicacion y crear
            //*******FALTA AGREGAR todo lo necesario para el alta de una persona..
            var userPerson = _mapper.Map<UserPerson>(userPersonRequest);
            var response = await _userPersonAplication.CreatePerson(userPerson);
            //return base.Create(entityDto);
            return response;
        }
    }
}
