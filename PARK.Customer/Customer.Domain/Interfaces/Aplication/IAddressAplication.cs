using Domain.Entities;
using System.Threading.Tasks;

namespace Domain.Interfaces.Aplication
{
    public interface IAddressAplication
    {
        Task<Address> PostCustomerAddress(Address address);

    }
}
