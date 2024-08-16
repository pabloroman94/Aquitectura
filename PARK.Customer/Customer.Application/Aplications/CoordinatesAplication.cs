using Domain.Entities;
using Domain.Entities.Filters;
using Domain.Interfaces.Aplication;
using Domain.Interfaces.Aplication.SeedWork;
using Domain.Interfaces.Infraestructure.Data.SeedWork;
using System;

namespace Application.Aplications
{
    public class CoordinatesAplication : BaseCrudStampAplication<Coordinates, Guid, CoordinatesFilter>,
                                   IBaseCrudStampAplication<Coordinates, Guid, CoordinatesFilter>,
                                   ICoordinatesAplication
    {
        public CoordinatesAplication(IBaseRepository<Coordinates, Guid, CoordinatesFilter> repository) : base(repository)
        {
        }
    }
}
