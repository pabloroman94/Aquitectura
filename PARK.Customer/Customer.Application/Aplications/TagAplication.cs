using Domain.Entities;
using Domain.Entities.Filters;
using Domain.Interfaces.Aplication;
using Domain.Interfaces.Aplication.SeedWork;
using Domain.Interfaces.Infraestructure.Data.SeedWork;
using System;

namespace Application.Aplications
{
    public class TagAplication : BaseCrudStampAplication<Tag, Guid, TagFilter>,
                                   IBaseCrudStampAplication<Tag, Guid, TagFilter>,
                                   ITagAplication
    {
        public TagAplication(IBaseRepository<Tag, Guid, TagFilter> repository) : base(repository)
        {
        }
    }
}
