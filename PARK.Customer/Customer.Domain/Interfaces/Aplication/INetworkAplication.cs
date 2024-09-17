using Domain.Entities;
using System.Threading.Tasks;

namespace Domain.Interfaces.Aplication
{
    public interface INetworkAplication
    {
        ValueTask<Network> Create(Network entity);
    }
}
