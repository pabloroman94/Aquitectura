using Domain.Entities;
using Domain.Entities.Filters;
using Domain.Interfaces.Aplication;
using Domain.Interfaces.Aplication.SeedWork;
using Domain.Interfaces.Infraestructure.Data.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Aplications
{
    public class CompanyContactPersonAplication : BaseCrudStampAplication<CompanyContactPerson, Guid, CompanyContactPersonFilter>,
                                   IBaseCrudStampAplication<CompanyContactPerson, Guid, CompanyContactPersonFilter>,
                                   ICompanyContactPersonAplication
    {
        public CompanyContactPersonAplication(IBaseRepository<CompanyContactPerson, Guid, CompanyContactPersonFilter> repository) : base(repository)
        {
        }
    }
}
