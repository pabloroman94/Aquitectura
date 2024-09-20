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
        public IEnumerable<UserPerson> GetPersonsByFilter()
        {
            var persons = _personRepository.GetPersonsByFilter();
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

            // Creación de listas con métodos auxiliares para evitar duplicación
            userPersonRequest.PersonTags = CreatePersonTags(currentDate, defaultUserName, userPersonRequest.PersonTags);
            userPersonRequest.PersonProfessions = CreatePersonProfessions(currentDate, defaultUserName, defaultCode, userPersonRequest.PersonProfessions);
            userPersonRequest.Networks = CreateNetworks(currentDate, defaultUserName, defaultCode, userPersonRequest.Networks);
            userPersonRequest.UserAddresses = CreateUserAddresses(currentDate, defaultUserName, defaultCode, userPersonRequest.UserAddresses);

            // Llamar al método base para crear el objeto
            var createdUserPerson = await base.Create(userPersonRequest);


            var userPersonWithRelations = base._repositorio.Get(new UserPersonSpecification(createdUserPerson.Id));


            return userPersonWithRelations.FirstOrDefault();

            //return createdUserPerson;
        }

        // Métodos auxiliares para crear los objetos anidados
        private ICollection<PersonTag> CreatePersonTags(DateTime currentDate, string userName, ICollection<PersonTag> personTags)
        {
            foreach (var item in personTags)
            {
                item.FInsert = currentDate;
                item.UserName = userName;
                item.FUpdate = currentDate;
                item.UserNameUpdate = userName;
                item.Code = string.Empty;
            }
            return personTags;
            //return new List<PersonTag>
            //{
            //    new PersonTag
            //    {
            //        FInsert = currentDate,
            //        UserName = userName,
            //        FUpdate = currentDate,
            //        UserNameUpdate = userName,
            //        Code = string.Empty,  // Si el código no es necesario, puede estar vacío o en constante
            //        TagID = new Guid("08dcbf02-3811-4a3e-83b5-da93f0603c38")
            //    }
            //};
        }

        private ICollection<PersonProfession> CreatePersonProfessions(DateTime currentDate, string userName, string code, ICollection<PersonProfession> personProfessions)
        {
            foreach (var item in personProfessions)
            {
                item.FInsert = currentDate;
                item.UserName = userName;
                item.FUpdate = currentDate;
                item.UserNameUpdate = userName;
                item.Code = string.Empty;
            }
            return personProfessions;
            //return new List<PersonProfession>
            //{
            //    new PersonProfession
            //    {
            //        FInsert = currentDate,
            //        UserName = userName,
            //        FUpdate = currentDate,
            //        UserNameUpdate = userName,
            //        Code = code,
            //        ProfessionID = new Guid("08dcbef4-12e7-414f-8d43-da3a1ac2f85c")
            //    }
            //};
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
