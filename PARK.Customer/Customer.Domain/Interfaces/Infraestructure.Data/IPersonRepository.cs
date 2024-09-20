using Domain.Entities;
using System;
using System.Collections.Generic;

namespace Domain.Interfaces.Infraestructure.Data
{
    public interface IPersonRepository
    {
        IEnumerable<UserPerson> GetPersonsByFilter();
        UserPerson GetPersonById(Guid id);
    }
}
