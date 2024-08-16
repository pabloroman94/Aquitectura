using Domain.Entities;
using Domain.Entities.Filters;
using Domain.Interfaces.Aplication;
using Domain.Interfaces.Aplication.SeedWork;
using Domain.Interfaces.Infraestructure.Data.SeedWork;
using System;

namespace Application.Aplications
{
    public class ProvinceAplication : BaseCrudStampAplication<Province, Guid, ProvinceFilter>,
                                   IBaseCrudStampAplication<Province, Guid, ProvinceFilter>,
                                   IProvinceAplication
    {
        public ProvinceAplication(IBaseRepository<Province, Guid, ProvinceFilter> repository) : base(repository)
        {
        }
    }
}
