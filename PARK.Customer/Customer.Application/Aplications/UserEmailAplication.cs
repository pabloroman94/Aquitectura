using Domain.Entities;
using Domain.Entities.Filters;
using Domain.Interfaces.Aplication;
using Domain.Interfaces.Aplication.SeedWork;
using Domain.Interfaces.Infraestructure.Data.SeedWork;
using System;

namespace Application.Aplications
{
    public class UserEmailAplication : BaseCrudStampAplication<UserEmail, Guid, UserEmailFilter>,
                                   IBaseCrudStampAplication<UserEmail, Guid, UserEmailFilter>,
                                   IUserEmailAplication
    {
        public UserEmailAplication(IBaseRepository<UserEmail, Guid, UserEmailFilter> repository) : base(repository)
        {
        }
    }
}
