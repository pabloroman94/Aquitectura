using Domain.Entities;
using Domain.Entities.Filters;
using Domain.Interfaces.Aplication;
using Domain.Interfaces.Aplication.SeedWork;
using Domain.Interfaces.Infraestructure.Data.SeedWork;
using System;

namespace Application.Aplications
{
    public class UserCategoryAplication : BaseCrudStampAplication<UserCategory, Guid, UserCategoryFilter>,
                                   IBaseCrudStampAplication<UserCategory, Guid, UserCategoryFilter>,
                                   IUserCategoryAplication
    {
        public UserCategoryAplication(IBaseRepository<UserCategory, Guid, UserCategoryFilter> repository) : base(repository)
        {
        }
    }
}
