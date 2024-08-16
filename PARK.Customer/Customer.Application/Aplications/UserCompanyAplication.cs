using Domain.Entities;
using Domain.Entities.Filters;
using Domain.Interfaces.Aplication;
using Domain.Interfaces.Aplication.SeedWork;
using Domain.Interfaces.Infraestructure.Data.SeedWork;
using System;

namespace Application.Aplications
{
    public class UserCompanyAplication : BaseCrudStampAplication<UserCompany, Guid, UserCompanyFilter>,
                                   IBaseCrudStampAplication<UserCompany, Guid, UserCompanyFilter>,
                                   IUserCompanyAplication
    {
        public UserCompanyAplication(IBaseRepository<UserCompany, Guid, UserCompanyFilter> repository) : base(repository)
        {
        }
    }
}
