using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces.Aplication
{
    public interface ICustomerAplication
    {
        Task<IEnumerable<Customer>> GetByDocument(string documentType, string documentNumber);
        Task<Customer> PostCustomer(Customer customer);
    }
}