using Domain.Entities;
using Domain.Entities.Filters;
using Domain.Interfaces.Aplication;
using Domain.Interfaces.Aplication.SeedWork;
using Domain.Interfaces.Infraestructure.Data.SeedWork;
using System;

namespace Application.Aplications
{
    public class UserPersonAplication : BaseCrudStampAplication<UserPerson, Guid, UserPersonFilter>,
                                   IBaseCrudStampAplication<UserPerson, Guid, UserPersonFilter>,
                                   IUserPersonAplication
    {
        public UserPersonAplication(IBaseRepository<UserPerson, Guid, UserPersonFilter> repository) : base(repository)
        {
        }
    }
}
