using Domain.Entities;
using Domain.Entities.Filters;
using Domain.Interfaces.Aplication;
using Domain.Interfaces.Aplication.SeedWork;
using Domain.Interfaces.Infraestructure.Data.SeedWork;
using System;

namespace Application.Aplications
{
    public class UserAddressAplication : BaseCrudStampAplication<UserAddress, Guid, UserAddressFilter>,
                                   IBaseCrudStampAplication<UserAddress, Guid, UserAddressFilter>,
                                   IUserAddressAplication
    {
        public UserAddressAplication(IBaseRepository<UserAddress, Guid, UserAddressFilter> repository) : base(repository)
        {
        }
    }
}
