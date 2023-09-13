using Domain.Entities;
using Domain.Entities.Filters;
using Domain.Interfaces.Aplication;
using Domain.Interfaces.Aplication.SeedWork;
using Domain.Interfaces.Infraestructure.Data.SeedWork;
using System;

namespace Application.Aplications
{
    public class GenderAplication : BaseCrudStampAplication<Gender, Guid, GenderFilter>,
                                   IBaseCrudStampAplication<Gender, Guid, GenderFilter>,
                                   IGenderAplication
    {
        public GenderAplication(IBaseRepository<Gender, Guid, GenderFilter> repository) : base(repository)
        {
        }
    }
}
