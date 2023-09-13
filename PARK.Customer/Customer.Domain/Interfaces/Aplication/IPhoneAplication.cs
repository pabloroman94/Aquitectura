using Domain.Entities;
using System.Threading.Tasks;

namespace Domain.Interfaces.Aplication
{
    public interface IPhoneAplication
    {
        Task<Phone> PostCustomerPhone(Phone customerPhone);
    }
}
