using Application.Specifications;
using AutoMapper;
using Domain.Entities;
using Domain.Entities.Filters;
using Domain.Interfaces.Aplication;
using Domain.Interfaces.Aplication.SeedWork;
using Domain.Interfaces.Infraestructure.Data.SeedWork;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Aplications
{
    public class PersonAplication : BaseCrudStampAplication<Person, Guid, PersonFilter>,
                                   IBaseCrudStampAplication<Person, Guid, PersonFilter>,
                                   IPersonAplication
    {
        public readonly ICustomerAplication _customerAplication;
        public readonly IAddressAplication _customerAddressAplication;
        public readonly IMailAplication _customerMailAplication;
        public readonly IPhoneAplication _phoneAplication;
        public readonly IMapper _mapper;
        public PersonAplication(IBaseRepository<Person, Guid, PersonFilter> repositorio, ICustomerAplication customerAplication,
            IAddressAplication customerAddressAplication, IMailAplication customerMailAplication, IPhoneAplication phoneAplication, IMapper mapper)
            : base(repositorio)
        {
            _customerAplication = customerAplication;
            _customerAddressAplication = customerAddressAplication;
            _customerMailAplication = customerMailAplication;
            _phoneAplication = phoneAplication;
            _mapper=mapper;
        }

        public async Task<IEnumerable<Person>> GetPersonByDocument(Guid? documentType, int documentNumber)
        {
            var result = base._repositorio.Get(new PersonSpecification(documentType, documentNumber));
            return result;
        }
        public async Task<IEnumerable<Person>> GetPersonByNameAndLastname(string name, string lastname)
        {
            var result = base._repositorio.Get(new PersonSpecification(name, lastname));
            return result;
        }
    }
}