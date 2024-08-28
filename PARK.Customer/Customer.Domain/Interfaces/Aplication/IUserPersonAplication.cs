using Domain.Entities;
using System.Threading.Tasks;

namespace Domain.Interfaces.Aplication
{
    public interface IUserPersonAplication
    {
        Task<UserPerson> CreatePerson(UserPerson userPersonRequest);
    }
}
