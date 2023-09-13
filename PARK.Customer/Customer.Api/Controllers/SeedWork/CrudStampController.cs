using AutoMapper;
using CustomerApp.Api.CustomEntities;
using CustomerApp.Api.Services;
using Domain.Entities;
using Domain.Interfaces.Aplication.SeedWork;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using PARK.CustomerApi.Models;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace PARK.CustomerApi.Controllers
{
    public abstract class CrudStampController<TEntity, TPrimaryKey, TEntityDto, TFilters> : BaseController<TEntity>
                                                                                            where TEntity : BaseStampEntity<TPrimaryKey>
                                                                                            where TFilters : Filter
    {
        protected internal IMapper _mapper;
        protected internal IBaseStampAplication<TEntity, TPrimaryKey, TFilters> _aplicacion;
        private readonly IUriService _uriService;
        private readonly PaginationOptions _paginationOptions;


        public CrudStampController(IMapper mapper,
                              IBaseStampAplication<TEntity, TPrimaryKey, TFilters> aplicacion,
                              IUriService uriService,
                              IOptions<PaginationOptions> options,
                              ILogger<TEntity> logger = null) : base(logger)
        {
            _mapper = mapper;
            _aplicacion = aplicacion;
            _uriService = uriService;
            _paginationOptions = options.Value;

        }


        [HttpPost("GetByFilters")]
        public virtual IActionResult GetByFiltros(TFilters filters)
        {

            this._logger.LogInformation("Getting GetByFiltros : ip {ip} -> custom property : {entity}", this.GenerateIPAddress(), typeof(TEntity).Name.ToString());
            filters.PageNumber = filters.PageNumber == 0 ? _paginationOptions.DefaultPageNumber : filters.PageNumber;
            filters.PageSize = filters.PageSize == 0 ? _paginationOptions.DefaultPageSize : filters.PageSize;
            var entity = _aplicacion.Get(filters);
            var metadata = PagedList.Create<TEntity>(entity, filters, Request.Path.Value, _uriService);
            var entityDto = _mapper.Map<IEnumerable<TEntityDto>>(metadata);
            var response = new ApiResponseModel<IEnumerable<TEntityDto>>(entityDto);
            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata.pagedResponseHeader));

            _logger.LogInformation("Response OK");
            return Ok(response);
        }

        [HttpGet("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public virtual async Task<ActionResult<TEntity>> Get(TPrimaryKey id)
        {

            var entity = await _aplicacion.Get(id);
            var entityDto = _mapper.Map<TEntityDto>(entity);
            var response = new ApiResponseModel<TEntityDto>(entityDto);

            return Ok(response);
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public virtual async Task<ActionResult> Create(TEntityDto entityDto)
        {
            this._logger.LogInformation("Getting Create : ip {ip} -> custom property : {entity}", this.GenerateIPAddress(), entityDto);
            var entity = _mapper.Map<TEntity>(entityDto);
            var entityCreated = await _aplicacion.Create(entity);

            var entityCreatedDto = _mapper.Map<TEntityDto>(entityCreated);
            var response = new ApiResponseModel<TEntityDto>(entityCreatedDto);

            return Ok(response);
        }

        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public virtual async Task<ActionResult> Update(TEntityDto entityDto)
        {
            var entity = _mapper.Map<TEntity>(entityDto);
            var entityUpdated = await _aplicacion.Update(entity);

            var entityCreatedDto = _mapper.Map<TEntityDto>(entityUpdated);
            var response = new ApiResponseModel<TEntityDto>(entityCreatedDto);

            return Ok(response);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public virtual async Task<ActionResult> Delete(TPrimaryKey id)
        {
            await _aplicacion.Delete(id);
            var response = new ApiResponseModel<string>("");

            return Ok(response);
        }
    }
}
