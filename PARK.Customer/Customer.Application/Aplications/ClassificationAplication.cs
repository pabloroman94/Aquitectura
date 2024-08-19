using Domain.Entities;
using Domain.Entities.Filters;
using Domain.Interfaces.Aplication;
using Domain.Interfaces.Aplication.SeedWork;
using Domain.Interfaces.Infraestructure.Data.SeedWork;
using System;

namespace Application.Aplications
{
    public class ClassificationAplication : BaseCrudStampAplication<Classification, Guid, ClassificationFilter>,
                                   IBaseCrudStampAplication<Classification, Guid, ClassificationFilter>,
                                   IClassificationAplication
    {
        public ClassificationAplication(IBaseRepository<Classification, Guid, ClassificationFilter> repository) : base(repository)
        {
        }
    }
}
