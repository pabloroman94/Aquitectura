using Application.Specifications;
using Domain.Entities;
using Domain.Entities.Filters;
using Domain.Interfaces.Aplication;
using Domain.Interfaces.Aplication.SeedWork;
using Domain.Interfaces.Infraestructure.Data.SeedWork;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Aplications
{
    public class CompanyAplication : BaseCrudStampAplication<Company, Guid, CompanyFilter>,
                                   IBaseCrudStampAplication<Company, Guid, CompanyFilter>,
                                   ICompanyAplication
    {
        public CompanyAplication(IBaseRepository<Company, Guid, CompanyFilter> repositorio)
          : base(repositorio)
        { }
        public async Task<IEnumerable<Company>> GetCompanyBydocument(Guid? documentType, int documentNumber)
        {
            var result = base._repositorio.Get(new CompanySpecification(documentType, documentNumber));
            return result;
        }
        public async Task<IEnumerable<Company>> GetCompanyByName(string nameCompany)
        {
            var result = base._repositorio.Get(new CompanySpecification(nameCompany));
            return result;
        }
    }
}
