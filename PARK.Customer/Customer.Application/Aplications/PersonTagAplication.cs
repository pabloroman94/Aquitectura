using Domain.Entities;
using Domain.Entities.Filters;
using Domain.Interfaces.Aplication;
using Domain.Interfaces.Aplication.SeedWork;
using Domain.Interfaces.Infraestructure.Data.SeedWork;
using System;

namespace Application.Aplications
{
    public class PersonTagAplication : BaseCrudStampAplication<PersonTag, Guid, PersonTagFilter>,
                                   IBaseCrudStampAplication<PersonTag, Guid, PersonTagFilter>,
                                   IPersonTagAplication
    {
        public PersonTagAplication(IBaseRepository<PersonTag, Guid, PersonTagFilter> repository) : base(repository)
        {
        }
    }
}
