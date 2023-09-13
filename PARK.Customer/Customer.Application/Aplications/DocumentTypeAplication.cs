using Domain.Entities;
using Domain.Entities.Filters;
using Domain.Interfaces.Aplication;
using Domain.Interfaces.Aplication.SeedWork;
using Domain.Interfaces.Infraestructure.Data.SeedWork;
using System;

namespace Application.Aplications
{
    public class DocumentTypeAplication : BaseCrudStampAplication<DocumentType, Guid, DocumentTypeFilter>,
                                   IBaseCrudStampAplication<DocumentType, Guid, DocumentTypeFilter>,
                                   IDocumentTypeAplication
    {
        public DocumentTypeAplication(IBaseRepository<DocumentType, Guid, DocumentTypeFilter> repository) : base(repository)
        {
        }
    }
}