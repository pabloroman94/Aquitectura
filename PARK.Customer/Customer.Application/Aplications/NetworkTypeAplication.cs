using Domain.Entities;
using Domain.Entities.Filters;
using Domain.Interfaces.Aplication;
using Domain.Interfaces.Aplication.SeedWork;
using Domain.Interfaces.Infraestructure.Data.SeedWork;
using System;

namespace Application.Aplications
{
    public class NetworkTypeAplication : BaseCrudStampAplication<NetworkType, Guid, NetworkTypeFilter>,
                                   IBaseCrudStampAplication<NetworkType, Guid, NetworkTypeFilter>,
                                   INetworkTypeAplication
    {
        public NetworkTypeAplication(IBaseRepository<NetworkType, Guid, NetworkTypeFilter> repository) : base(repository)
        {
        }
    }
}
