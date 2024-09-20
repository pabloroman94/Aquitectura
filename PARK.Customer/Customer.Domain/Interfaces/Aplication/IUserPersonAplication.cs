using Domain.Entities;
using Domain.Entities.Filters;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces.Aplication
{
    public interface IUserPersonAplication
    {
        Task<UserPerson> CreatePerson(UserPerson userPersonRequest);
        IEnumerable<UserPerson> GetPersonsByFilter();
        UserPerson GetPersonById(Guid id);
        //IEnumerable<UserPerson> GetCardPersons();
    }
}
