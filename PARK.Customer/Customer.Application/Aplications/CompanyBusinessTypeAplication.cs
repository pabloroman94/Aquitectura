using Domain.Entities;
using Domain.Entities.Filters;
using Domain.Interfaces.Aplication;
using Domain.Interfaces.Aplication.SeedWork;
using Domain.Interfaces.Infraestructure.Data.SeedWork;
using System;

namespace Application.Aplications
{
    public class CompanyBusinessTypeAplication : BaseCrudStampAplication<CompanyBusinessType, Guid, CompanyBusinessTypeFilter>,
                                   IBaseCrudStampAplication<CompanyBusinessType, Guid, CompanyBusinessTypeFilter>,
                                   ICompanyBusinessTypeAplication
    {
        public CompanyBusinessTypeAplication(IBaseRepository<CompanyBusinessType, Guid, CompanyBusinessTypeFilter> repository) : base(repository)
        {
        }
    }
}
