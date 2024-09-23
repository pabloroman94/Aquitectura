using Application.Specifications;
using Domain.Entities;
using Domain.Entities.Filters;
using Domain.Interfaces.Aplication;
using Domain.Interfaces.Aplication.SeedWork;
using Domain.Interfaces.Infraestructure.Data;
using Domain.Interfaces.Infraestructure.Data.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Aplications
{
    public class UserPersonAplication : BaseCrudStampAplication<UserPerson, Guid, UserPersonFilter>,
                                   IBaseCrudStampAplication<UserPerson, Guid, UserPersonFilter>,
                                   IUserPersonAplication
    {
        private readonly INetworkAplication _networkAplication;

        private readonly IPersonRepository _personRepository;


        private readonly IBaseRepository<UserPerson, Guid, UserPersonFilter> _repository;



        public UserPersonAplication(IPersonRepository personRepository, INetworkAplication networkAplication, IBaseRepository<UserPerson, Guid, UserPersonFilter> repository) : base(repository)
        {
            this._networkAplication = networkAplication;
            this._repository = repository;
            _personRepository = personRepository;

        }
        public IEnumerable<UserPerson> GetAllPersons()
        {
            var persons = _personRepository.GetAllPersons();
            return persons;
        }
        public UserPerson GetPersonById(Guid id)
        {
            var persons = _personRepository.GetPersonById(id);

            return persons;
        }

        public async Task<UserPerson> CreatePerson(UserPerson userPersonRequest)
        {
            if (userPersonRequest == null)
            {
                throw new ArgumentNullException(nameof(userPersonRequest));
            }

            // Constantes para valores repetidos
            const string defaultUserName = "";
            const string defaultCode = "";
            var currentDate = DateTime.Now;

            // Asignación del código
            userPersonRequest.Code = "123456";
            
            var tags = _personRepository.GetTags(userPersonRequest.Tags);
            userPersonRequest.PersonTags = CreatePersonTags(currentDate, defaultUserName, tags);

            var professions = _personRepository.GetProfessions(userPersonRequest.Professions);
            userPersonRequest.PersonProfessions = CreatePersonProfessions(currentDate, defaultUserName, professions);
            

            //userPersonRequest.UserAddresses = CreateUserAddresses(currentDate, defaultUserName, defaultCode, userPersonRequest.UserAddresses);

            // Llamar al método base para crear el objeto
            var createdUserPerson = await base.Create(userPersonRequest);

            var networks = _personRepository.GetNetworks(userPersonRequest.NetworkProfiles, createdUserPerson.Id);
            userPersonRequest.Networks = networks;//CreateNetworks(currentDate, defaultUserName, defaultCode, networks);

            var addresses = _personRepository.GetUserAddresses(userPersonRequest.AddressProfile, createdUserPerson.Id);
            userPersonRequest.UserAddresses = addresses;//CreateNetworks(currentDate, defaultUserName, defaultCode, networks);

            //var userPersonWithRelations = base._repositorio.Get(new UserPersonSpecification(createdUserPerson.Id));
            var persons = _personRepository.GetPersonById(createdUserPerson.Id);


            return persons;

            //return createdUserPerson;
        }

        // Métodos auxiliares para crear los objetos anidados
        private ICollection<PersonTag> CreatePersonTags(DateTime currentDate, string userName, ICollection<Tag> Tags)
        {
            // Inicializamos la lista de personTags
            List<PersonTag> personTags = new List<PersonTag>();

            // Iteramos sobre la colección de Tags
            foreach (var item in Tags)
            {
                // Añadimos un nuevo PersonTag a la lista
                personTags.Add(new PersonTag
                {
                    FInsert = currentDate,
                    UserName = userName,
                    FUpdate = currentDate,
                    UserNameUpdate = userName,
                    Code = string.Empty,
                    TagID = item.Id
                });
            }

            return personTags;
        }

        private ICollection<PersonProfession> CreatePersonProfessions(DateTime currentDate, string userName, ICollection<Profession> professions)
        {
            // Inicializamos la lista de PersonProfession
            List<PersonProfession> personProfessions = new List<PersonProfession>();

            // Iteramos sobre la colección de Professions
            foreach (var profession in professions)
            {
                // Añadimos un nuevo PersonProfession a la lista
                personProfessions.Add(new PersonProfession
                {
                    FInsert = currentDate,
                    UserName = userName,
                    FUpdate = currentDate,
                    UserNameUpdate = userName,
                    Code = string.Empty,
                    ProfessionID = profession.Id // Usamos el ID de la profesión
                });
            }

            return personProfessions;
        }


        private ICollection<Network> CreateNetworks(DateTime currentDate, string userName, string code, ICollection<Network> networks)
        {
            foreach (var item in networks)
            {
                item.FInsert = currentDate;
                item.UserName = userName;
                item.FUpdate = currentDate;
                item.UserNameUpdate = userName;
                item.Code = string.Empty;
            }
            return networks;
            //return new List<Network>
            //{
            //    new Network
            //    {
            //        FInsert = currentDate,
            //        UserName = userName,
            //        FUpdate = currentDate,
            //        UserNameUpdate = userName,
            //        Code = code,
            //        Description = "Facebook",
            //        URL = "https://www.facebook.com",
            //        NetworkTypeID = new Guid("08dcbfe1-177a-4f97-87bb-02acadabf588")
            //    }
            //};
        }

        private ICollection<UserAddress> CreateUserAddresses(DateTime currentDate, string userName, string code, ICollection<UserAddress> userAddresses)
        {
            foreach (var item in userAddresses)
            {
                item.FInsert = currentDate;
                item.UserName = userName;
                item.FUpdate = currentDate;
                item.UserNameUpdate = userName;
                item.Code = string.Empty;
            }
            return userAddresses;
            //return new List<UserAddress>
            //{
            //    new UserAddress
            //    {
            //        FInsert = currentDate,
            //        UserName = userName,
            //        FUpdate = currentDate,
            //        UserNameUpdate = userName,
            //        Code = code,
            //        StreetID = new Guid("08dcbfed-afd6-4c1d-8abd-51599b6d10c4"),
            //        CoordinatesID = new Guid("08dcbfee-598c-436c-821e-4eeea81ca128")
            //    }
            //};
        }

    }
}
