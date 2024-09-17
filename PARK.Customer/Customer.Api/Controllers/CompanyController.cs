using AutoMapper;
using Customer.Api.Models;
using Customer.Api.Models.Request;
using CustomerApp.Api.CustomEntities;
using CustomerApp.Api.Services;
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

namespace Customer.Api.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class CompanyController : CrudStampController<TestResponse, Domain.Entities.Company, Guid, CompanyModel, CompanyFilter>
    {
        private readonly ICompanyAplication _companyAplication;

        public CompanyController(ICompanyAplication companyAplication, IMapper mapper, IBaseStampAplication<Domain.Entities.Company, Guid, CompanyFilter> aplicacion, IUriService uriService, IOptions<PaginationOptions> options, ILogger<Domain.Entities.Company> logger = null) : base(mapper, aplicacion, uriService, options, logger)
        {
            this._companyAplication = companyAplication;
        }
        /// <param name="documentType">315DEDE6-1BA9-9A51-E053-9701C781E30D</param>
        /// <param name="documentNumber">12345678</param>
        [HttpGet()]
        [Route("CompanyByDocument")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public virtual async Task<ActionResult<IEnumerable<CompanyModel>>> CompanyByDocument(Guid documentType , int documentNumber)
        {
            var entity = await _companyAplication.GetCompanyBydocument(documentType, documentNumber);
            var entityDto = _mapper.Map<IEnumerable<CompanyModel>>(entity);
            var response = new ApiResponseModel<IEnumerable<CompanyModel>>(entityDto);

            return Ok(response);
        }
        /// <param name="nameCompany">cocacola</param>

        [HttpGet()]
        [Route("CompanyByNameCompany")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public virtual async Task<ActionResult<IEnumerable<CompanyModel>>> CompanyByNameCompany(string nameCompany)
        {
            var entity = await _companyAplication.GetCompanyByName(nameCompany);
            var entityDto = _mapper.Map<IEnumerable<CompanyModel>>(entity);
            var response = new ApiResponseModel<IEnumerable<CompanyModel>>(entityDto);

            return Ok(response);
        }

    }
}
