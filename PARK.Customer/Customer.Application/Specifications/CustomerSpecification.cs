using Domain.Entities;
using Domain.Entities.Enums;
using System;

namespace Application.Specifications
{
    public class CustomerSpecification : BaseSpecification<Customer>
    {
        public CustomerSpecification(int pageNumber = 0, int pageSize = 0) : base(x => x.Active.Equals(BoolCharEnum.Y))
        {
            ApplyOrderBy(x => x.Id);
            ApplyPaging(pageNumber, pageSize);
        }
        public CustomerSpecification(Guid id) : base(x => x.Id.Equals(id) && x.Active.Equals(BoolCharEnum.Y))
        {
            ApplyOrderBy(x => x.Id);
        }
    }
}