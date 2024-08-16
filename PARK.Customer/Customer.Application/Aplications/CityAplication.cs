using Domain.Entities;
using Domain.Entities.Filters;
using Domain.Interfaces.Aplication;
using Domain.Interfaces.Aplication.SeedWork;
using Domain.Interfaces.Infraestructure.Data.SeedWork;
using System;

namespace Application.Aplications
{
    public class CityAplication : BaseCrudStampAplication<City, Guid, CityFilter>,
                                   IBaseCrudStampAplication<City, Guid, CityFilter>,
                                   ICityAplication
    {
        public CityAplication(IBaseRepository<City, Guid, CityFilter> repository) : base(repository)
        {
        }
    }
}
