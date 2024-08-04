using Domain.Entities;
using Domain.Entities.Filters;
using Domain.Interfaces.Aplication;
using Domain.Interfaces.Aplication.SeedWork;
using Domain.Interfaces.Infraestructure.Data.SeedWork;
using System;

namespace Application.Aplications
{
    public class UserAplication : BaseCrudStampAplication<User, Guid, UserFilter>,
                                   IBaseCrudStampAplication<User, Guid, UserFilter>,
                                   IUserAplication
    {
        public UserAplication(IBaseRepository<User, Guid, UserFilter> repository) : base(repository)
        {
        }
    }
}
