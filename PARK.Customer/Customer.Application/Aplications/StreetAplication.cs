using Domain.Entities;
using Domain.Entities.Filters;
using Domain.Interfaces.Aplication;
using Domain.Interfaces.Aplication.SeedWork;
using Domain.Interfaces.Infraestructure.Data.SeedWork;
using System;

namespace Application.Aplications
{
    public class StreetAplication : BaseCrudStampAplication<Street, Guid, StreetFilter>,
                                   IBaseCrudStampAplication<Street, Guid, StreetFilter>,
                                   IStreetAplication
    {
        public StreetAplication(IBaseRepository<Street, Guid, StreetFilter> repository) : base(repository)
        {
        }
    }
}
