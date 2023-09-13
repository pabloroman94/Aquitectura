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
    public class PhoneAplication : BaseCrudStampAplication<Phone, Guid, PhoneFilter>,
                                   IBaseCrudStampAplication<Phone, Guid, PhoneFilter>,
                                   IPhoneAplication
    {
        public PhoneAplication(IBaseRepository<Phone, Guid, PhoneFilter> repository) : base(repository)
        {
        }

        public async Task<Phone> PostCustomerPhone(Phone customerPhone)
        {
            var result = await Create(customerPhone);
            return result;
        }
    }
}