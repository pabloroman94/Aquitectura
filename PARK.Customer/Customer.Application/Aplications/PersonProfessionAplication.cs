using Domain.Entities;
using Domain.Entities.Filters;
using Domain.Interfaces.Aplication;
using Domain.Interfaces.Aplication.SeedWork;
using Domain.Interfaces.Infraestructure.Data.SeedWork;
using System;

namespace Application.Aplications
{
    public class PersonProfessionAplication : BaseCrudStampAplication<PersonProfession, Guid, PersonProfessionFilter>,
                                   IBaseCrudStampAplication<PersonProfession, Guid, PersonProfessionFilter>,
                                   IPersonProfessionAplication
    {
        public PersonProfessionAplication(IBaseRepository<PersonProfession, Guid, PersonProfessionFilter> repository) : base(repository)
        {
        }
    }
}
