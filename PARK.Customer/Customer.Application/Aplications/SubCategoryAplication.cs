using Domain.Entities;
using Domain.Entities.Filters;
using Domain.Interfaces.Aplication;
using Domain.Interfaces.Aplication.SeedWork;
using Domain.Interfaces.Infraestructure.Data.SeedWork;
using System;

namespace Application.Aplications
{
    public class SubCategoryAplication : BaseCrudStampAplication<SubCategory, Guid, SubCategoryFilter>,
                                   IBaseCrudStampAplication<SubCategory, Guid, SubCategoryFilter>,
                                   ISubCategoryAplication
    {
        public SubCategoryAplication(IBaseRepository<SubCategory, Guid, SubCategoryFilter> repository) : base(repository)
        {
        }
    }
}
