using Domain.Entities;
using Domain.Entities.Filters;
using Domain.Interfaces.Aplication;
using Domain.Interfaces.Aplication.SeedWork;
using Domain.Interfaces.Infraestructure.Data.SeedWork;
using System;

namespace Application.Aplications
{
    public class BusinessTypeAplication : BaseCrudStampAplication<BusinessType, Guid, BusinessTypeFilter>,
                                   IBaseCrudStampAplication<BusinessType, Guid, BusinessTypeFilter>,
                                   IBusinessTypeAplication
    {
        public BusinessTypeAplication(IBaseRepository<BusinessType, Guid, BusinessTypeFilter> repository) : base(repository)
        {
        }
    }
}
