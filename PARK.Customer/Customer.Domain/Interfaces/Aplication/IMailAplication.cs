using Domain.Entities;
using System.Threading.Tasks;

namespace Domain.Interfaces.Aplication
{
    public interface IMailAplication
    {
        Task<Mail> PostCustomerMail(Mail customerMail);
    }
}
