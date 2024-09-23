using Domain.Entities;
using System;
using System.Collections.Generic;

namespace Domain.Interfaces.Infraestructure.Data
{
    public interface IPersonRepository
    {
        IEnumerable<UserPerson> GetAllPersons();
        UserPerson GetPersonById(Guid id);

        List<Tag> GetTags(List<string> listTag);
        List<Profession> GetProfessions(List<string> listProfession);
        List<Network> GetNetworks(ICollection<NetworkProfile> listNetwork, Guid Id);
        List<UserAddress> GetUserAddresses(AddressProfile listAddresses, Guid userId);
    }
}
