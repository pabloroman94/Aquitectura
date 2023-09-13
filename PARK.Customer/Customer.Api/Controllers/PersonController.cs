using AutoMapper;
using Customer.Api.Models;
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
using PARK.CustomerApi.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System.Linq;

namespace Customer.Api.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class PersonController : CrudStampController<Domain.Entities.Person, Guid, PersonModel, PersonFilter>
    {
        private readonly IPersonAplication _customerAplication;

        public PersonController(IPersonAplication customerAplication, IMapper mapper, IBaseStampAplication<Domain.Entities.Person, Guid, PersonFilter> aplicacion, IUriService uriService, IOptions<PaginationOptions> options, ILogger<Domain.Entities.Person> logger = null) 
            : base(mapper, aplicacion, uriService, options, logger)
        {
            this._customerAplication = customerAplication;
        }
        /// <param name="documentType">F2DFB2E7-B348-2F78-E053-9701C7813C55</param>
        /// <param name="documentNumber">38400904</param>
        [HttpGet()]
        [Route("GetPersonByDocument")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public virtual async Task<ActionResult<IEnumerable<PersonModel>>> PersonByDocument(Guid? documentType, int documentNumber)
        {
            var entity = await _customerAplication.GetPersonByDocument(documentType, documentNumber);
            var entityDto = _mapper.Map<IEnumerable<PersonModel>>(entity);
            var response = new ApiResponseModel<IEnumerable<PersonModel>>(entityDto);

            return Ok(response);
        }
        /// <param name="name">emanuel</param>
        /// <param name="lastname">roman</param>
        [HttpGet()]
        [Route("GetPersonByNameAndLastname")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public virtual async Task<ActionResult<IEnumerable<PersonModel>>> PersonByNameAndLastname(string name, string lastname)
        {
            var entity = await _customerAplication.GetPersonByNameAndLastname(name, lastname);
            var entityDto = _mapper.Map<IEnumerable<PersonModel>>(entity);
            var response = new ApiResponseModel<IEnumerable<PersonModel>>(entityDto);

            return Ok(response);
        }
    }
}