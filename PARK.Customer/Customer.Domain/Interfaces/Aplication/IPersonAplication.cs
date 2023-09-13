using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces.Aplication
{
    public interface IPersonAplication
    {
        Task<IEnumerable<Person>> GetPersonByDocument(Guid? documentType, int documentNumber);
        Task<IEnumerable<Person>> GetPersonByNameAndLastname(string name, string lastname);
    }
}