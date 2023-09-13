using Application.Specifications;
using Domain.Entities;
using Domain.Entities.Filters;
using Domain.Interfaces.Aplication;
using Domain.Interfaces.Aplication.SeedWork;
using Domain.Interfaces.Infraestructure.Data.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Aplications
{
    public class CustomerAplication : BaseCrudStampAplication<Customer, Guid, CustomerFilter>,
                                   IBaseCrudStampAplication<Customer, Guid, CustomerFilter>,
                                   ICustomerAplication
    {
        public CustomerAplication(IBaseRepository<Customer, Guid, CustomerFilter> repositorio)
            : base(repositorio)
        { }

        public override IEnumerable<Customer> Get(CustomerFilter filter)
        {
            var entity = _repositorio.Get(new CustomerSpecification(filter.PageNumber, filter.PageSize));
            return entity.ToList();
        }

        public async Task<IEnumerable<Customer>> GetByDocument(string documentType, string documentNumber)
        {
            var result = base._repositorio.Get( new CustomerListByDocument(documentType, documentNumber));
            return result;
        }
        public async Task<Customer> PostCustomer(Customer customer)
        {
            var result = await Create(customer);
            return result;
        }
    }
}
