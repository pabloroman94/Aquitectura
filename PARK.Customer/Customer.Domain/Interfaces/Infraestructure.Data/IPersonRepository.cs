using Domain.Entities;
using System.Collections.Generic;

namespace Domain.Interfaces.Infraestructure.Data
{
    public interface IPersonRepository
    {
        IEnumerable<UserPerson> GetPersonsByFilter();

    }
}
