using Domain.Entities;
using Domain.Entities.Enums;

namespace Application.Specifications
{
    public class GenderSpecification : BaseSpecification<Gender>
    {
        public GenderSpecification() : base(x => x.Active.Equals(BoolCharEnum.Y))
        {
            ApplyOrderBy(x => x.Id);
        }
    }
}
