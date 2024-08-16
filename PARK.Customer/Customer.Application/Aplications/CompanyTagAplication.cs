using Domain.Entities;
using Domain.Entities.Filters;
using Domain.Interfaces.Aplication;
using Domain.Interfaces.Aplication.SeedWork;
using Domain.Interfaces.Infraestructure.Data.SeedWork;
using System;

namespace Application.Aplications
{
    public class CompanyTagAplication : BaseCrudStampAplication<CompanyTag, Guid, CompanyTagFilter>,
                                   IBaseCrudStampAplication<CompanyTag, Guid, CompanyTagFilter>,
                                   ICompanyTagAplication
    {
        public CompanyTagAplication(IBaseRepository<CompanyTag, Guid, CompanyTagFilter> repository) : base(repository)
        {
        }
    }
}
