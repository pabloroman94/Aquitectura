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
    public class AddressAplication : BaseCrudStampAplication<Address, Guid, AddressFilter>,
                                   IBaseCrudStampAplication<Address, Guid, AddressFilter>,
                                   IAddressAplication
    {
        public AddressAplication(IBaseRepository<Address, Guid, AddressFilter> repository) 
            : base(repository)
        {}

        public async Task<Address> PostCustomerAddress(Address address)
        {
            var result = await Create(address);
            return result;
        }
    }
}
