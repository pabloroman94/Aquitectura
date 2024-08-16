using Domain.Entities;
using Domain.Entities.Filters;
using Domain.Interfaces.Aplication;
using Domain.Interfaces.Aplication.SeedWork;
using Domain.Interfaces.Infraestructure.Data.SeedWork;
using System;

namespace Application.Aplications
{
    public class NetworkAplication : BaseCrudStampAplication<Network, Guid, NetworkFilter>,
                                   IBaseCrudStampAplication<Network, Guid, NetworkFilter>,
                                   INetworkAplication
    {
        public NetworkAplication(IBaseRepository<Network, Guid, NetworkFilter> repository) : base(repository)
        {
        }
    }
}
