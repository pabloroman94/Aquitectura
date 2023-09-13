using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces.Aplication
{
    public interface ICompanyAplication
    {
        Task<IEnumerable<Company>> GetCompanyBydocument(Guid? documentType, int documentNumber);
        Task<IEnumerable<Company>> GetCompanyByName(string nameCompany);
    }
}