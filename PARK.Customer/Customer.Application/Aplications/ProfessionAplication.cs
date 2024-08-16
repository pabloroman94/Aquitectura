using Domain.Entities;
using Domain.Entities.Filters;
using Domain.Interfaces.Aplication;
using Domain.Interfaces.Aplication.SeedWork;
using Domain.Interfaces.Infraestructure.Data.SeedWork;
using System;

namespace Application.Aplications
{
    public class ProfessionAplication : BaseCrudStampAplication<Profession, Guid, ProfessionFilter>,
                                   IBaseCrudStampAplication<Profession, Guid, ProfessionFilter>,
                                   IProfessionAplication
    {
        public ProfessionAplication(IBaseRepository<Profession, Guid, ProfessionFilter> repository) : base(repository)
        {
        }
    }
}
