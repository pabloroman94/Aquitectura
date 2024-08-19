using Domain.Entities;
using Domain.Entities.Filters;
using Domain.Interfaces.Aplication;
using Domain.Interfaces.Aplication.SeedWork;
using Domain.Interfaces.Infraestructure.Data.SeedWork;
using System;

namespace Application.Aplications
{
    public class CountryAplication : BaseCrudStampAplication<Country, Guid, CountryFilter>,
                                   IBaseCrudStampAplication<Country, Guid, CountryFilter>,
                                   ICountryAplication
    {
        public CountryAplication(IBaseRepository<Country, Guid, CountryFilter> repository) : base(repository)
        {
        }
    }
}
