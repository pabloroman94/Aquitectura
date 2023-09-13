using Domain.Entities;
using Domain.Entities.Enums;

namespace Application.Specifications
{
    public class DocumentTypeSpecification : BaseSpecification<DocumentType>
    {
        public DocumentTypeSpecification() : base(x => x.Active.Equals(BoolCharEnum.Y))
        {
            ApplyOrderBy(x => x.Id);
        }
    }
}
