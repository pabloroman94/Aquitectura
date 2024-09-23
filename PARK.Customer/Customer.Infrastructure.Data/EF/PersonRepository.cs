using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Domain.Entities;
using Domain.Interfaces.Infraestructure.Data;
using Infrastructure.Data.EF;
using System;

namespace Customer.Infrastructure.Data.EF
{
    public class PersonRepository : IPersonRepository
    {
        private readonly Park_CustomerContext _context;

        public PersonRepository(Park_CustomerContext context) //: base(context)
        {
            _context = context;
        }

        public IEnumerable<UserPerson> GetAllPersons()
        {
            // Consulta con Include para traer PersonTags y PersonProfessions
            var result = _context.UserPeople
                .Include(up => up.PersonTags)           // Incluir la lista de PersonTags
                .ThenInclude(pt => pt.Tag)              // Incluir los Tags dentro de PersonTags

                .Include(up => up.PersonProfessions)    // Incluir la lista de PersonProfessions
                .ThenInclude(pp => pp.Profession)       // Incluir las Profesiones dentro de PersonProfessions

                .Include(up => up.Networks)
                .ThenInclude(pp => pp.NetworkType)

                .Include(up => up.UserAddresses)
                .ThenInclude(ua => ua.Street)           // Incluir Street dentro de UserAddresses
                .Include(up => up.UserAddresses)
                .ThenInclude(st => st.Coordinates)      // Incluir Coordinates dentro de Street


                .AsNoTracking()                         // Mejora el rendimiento si solo estás leyendo los datos
                .ToList();

            return result;
        }
        public List<Tag> GetTags(List<string> listTag)
        {
            if (listTag == null || !listTag.Any())
            {
                return new List<Tag>(); // Retorna lista vacía si no hay tags
            }

            // Consulta para obtener los Tags que ya existen en la base de datos
            var existingTags = _context.Tags
                .AsNoTracking()        // Usar AsNoTracking para mejorar el rendimiento en consultas de solo lectura
                .Where(t => listTag.Contains(t.TagName)) // Filtrar por los nombres de Tag contenidos en listTag
                .ToList();

            // Obtener los nombres de los tags que ya existen
            var existingTagNames = existingTags.Select(t => t.TagName).ToList();

            // Identificar los tags que no existen en la base de datos
            var newTagNames = listTag.Except(existingTagNames).ToList();

            // Si hay nuevos tags que no existen en la base de datos
            if (newTagNames.Any())
            {
                foreach (var tagName in newTagNames)
                {
                    // Crear un nuevo Tag si no existe
                    var newTag = new Tag
                    {
                        FInsert = DateTime.Now,
                        UserName = "asd",
                        FUpdate = DateTime.Now,
                        UserNameUpdate = "asd",
                        Code = "asd",
                        TagName = tagName
                    };
                    _context.Tags.Add(newTag);
                    existingTags.Add(newTag); // Añadir el nuevo Tag a la lista de resultados
                }

                // Guardar los cambios en la base de datos
                _context.SaveChanges();
            }

            return existingTags;
        }
        public List<Profession> GetProfessions(List<string> listProfession)
        {
            if (listProfession == null || !listProfession.Any())
            {
                return new List<Profession>(); // Retorna lista vacía si no hay profesiones
            }

            // Consulta para obtener las Profesiones que ya existen en la base de datos
            var existingProfessions = _context.Professions
                .AsNoTracking()        // Usar AsNoTracking para mejorar el rendimiento en consultas de solo lectura
                .Where(p => listProfession.Contains(p.ProfessionName)) // Filtrar por los nombres de Profesión contenidos en listProfession
                .ToList();

            // Obtener los nombres de las profesiones que ya existen
            var existingProfessionNames = existingProfessions.Select(p => p.ProfessionName).ToList();

            // Identificar las profesiones que no existen en la base de datos
            var newProfessionNames = listProfession.Except(existingProfessionNames).ToList();

            // Si hay nuevas profesiones que no existen en la base de datos
            if (newProfessionNames.Any())
            {
                foreach (var professionName in newProfessionNames)
                {
                    // Crear una nueva Profesión si no existe
                    var newProfession = new Profession
                    {
                        FInsert = DateTime.Now,
                        UserName = "asd",  // Asegúrate de que este campo tiene sentido en tu contexto
                        FUpdate = DateTime.Now,
                        UserNameUpdate = "asd",  // Asegúrate de que este campo tiene sentido en tu contexto
                        Code = "asd",  // Asegúrate de que este campo tiene sentido en tu contexto
                        CategoryID = new Guid("08dcbef3-eee5-4f71-8240-c9c1b6ac634d"),  // Asegúrate de que este campo tiene sentido en tu contexto
                        ProfessionName = professionName
                    };
                    _context.Professions.Add(newProfession);
                    existingProfessions.Add(newProfession); // Añadir la nueva Profesión a la lista de resultados
                }

                // Guardar los cambios en la base de datos
                _context.SaveChanges();
            }

            return existingProfessions;
        }
        public List<UserCategory> GetOrCreateUserCategories(List<string> categoryNames)
        {
            if (categoryNames == null || !categoryNames.Any())
            {
                return new List<UserCategory>(); // Retorna una lista vacía si no hay categorías
            }

            // Obtener las categorías que ya existen en la base de datos
            var existingCategories = _context.UserCategories
                .AsNoTracking()
                .Where(uc => categoryNames.Contains(uc.CategoryName)) // Filtrar las categorías que ya existen
                .ToList();

            // Obtener los nombres de las categorías existentes
            var existingCategoryNames = existingCategories.Select(uc => uc.CategoryName).ToList();

            // Identificar las categorías que no existen en la base de datos
            var newCategoryNames = categoryNames.Except(existingCategoryNames).ToList();

            // Si hay nuevas categorías que no existen en la base de datos
            if (newCategoryNames.Any())
            {
                foreach (var categoryName in newCategoryNames)
                {
                    // Verificar si la categoría ya existe en la tabla Category
                    var existingCategory = _context.UserCategories.SingleOrDefault(c => c.CategoryName == categoryName);
                    UserCategory category;

                    if (existingCategory == null)
                    {
                        // Crear una nueva categoría si no existe
                        category = new UserCategory { CategoryName = categoryName };
                        _context.UserCategories.Add(category);
                        _context.SaveChanges(); // Guardar la categoría en la base de datos
                    }
                    else
                    {
                        // Si la categoría ya existe, la utilizamos
                        category = existingCategory;
                    }

                    // Crear una nueva UserCategory con la nueva o existente Category
                    var newUserCategory = new UserCategory { CategoryName = categoryName };
                    _context.UserCategories.Add(newUserCategory);
                    existingCategories.Add(newUserCategory); // Añadir la nueva UserCategory a la lista de resultados
                }

                // Guardar los cambios en la base de datos
                _context.SaveChanges();
            }

            return existingCategories;
        }
        public List<Network> GetNetworks(ICollection<NetworkProfile> listNetwork, Guid Id)
        {
            if (listNetwork == null || !listNetwork.Any())
            {
                return new List<Network>(); // Retorna lista vacía si no hay redes
            }

            // Extraer los títulos de las redes sociales desde listNetwork
            var networkTitles = listNetwork.Select(np => np.Title).ToList();

            // Consulta para obtener las redes que ya existen en la base de datos
            var existingNetworks = _context.Networks
                .AsNoTracking()        // Usar AsNoTracking para mejorar el rendimiento en consultas de solo lectura
                .Where(n => networkTitles.Contains(n.Description)) // Filtrar por los títulos de redes contenidos en listNetwork
                .ToList();

            // Obtener los nombres de las redes que ya existen
            var existingNetworkTitles = existingNetworks.Select(n => n.Description).ToList();

            // Identificar las redes que no existen en la base de datos
            var newNetworkProfiles = listNetwork.Where(np => !existingNetworkTitles.Contains(np.Title)).ToList();

            // Si hay nuevas redes que no existen en la base de datos
            if (newNetworkProfiles.Any())
            {
                foreach (var networkProfile in newNetworkProfiles)
                {
                    // Crear una nueva Network si no existe
                    var newNetwork = new Network
                    {
                        FInsert = DateTime.Now,
                        UserName = "asd",  // Asegúrate de que este campo tiene sentido en tu contexto
                        FUpdate = DateTime.Now,
                        UserNameUpdate = "asd",  // Asegúrate de que este campo tiene sentido en tu contexto
                        Code = "asd",  // Asegúrate de que este campo tiene sentido en tu contexto
                        Description = networkProfile.Title,
                        //URL = networkProfile.UrlIcon,//AGREGAR propiedad en clase Network
                        //ButtonColor = networkProfile.ButtonColor,//AGREGAR propiedad en clase Network
                        PhoneNumber = networkProfile.PhoneNumber,
                        URL = networkProfile.UrlNetwork,
                        UserID = Id,
                        NetworkTypeID = new Guid("08dcbfe1-177a-4f97-87bb-02acadabf588")
                    };
                    _context.Networks.Add(newNetwork);
                    existingNetworks.Add(newNetwork); // Añadir la nueva Network a la lista de resultados
                }

                // Guardar los cambios en la base de datos
                _context.SaveChanges();
            }

            return existingNetworks;
        }

        public List<UserAddress> GetUserAddresses(AddressProfile listAddresses, Guid userId)
        {
            if (listAddresses == null )
            {
                return new List<UserAddress>(); // Retorna lista vacía si no hay direcciones
            }

            //// Extraer las descripciones de las direcciones desde listAddresses
            //var addressDescriptions = listAddresses.Select(ua => ua.Street).ToList();

            //// Consulta para obtener las direcciones que ya existen en la base de datos
            var existingAddresses = _context.UserAddresses
                .AsNoTracking()        // Usar AsNoTracking para mejorar el rendimiento en consultas de solo lectura
                .Where(ua => ua.Street.StreetName.Contains(listAddresses.StreetName)) // Filtrar por descripciones de direcciones
                .ToList();

            //// Obtener las descripciones de las direcciones que ya existen
            //var existingAddressDescriptions = existingAddresses.Select(ua => ua.Description).ToList();

            //// Identificar las direcciones que no existen en la base de datos
            //var newAddresses = listAddresses.Where(ua => !existingAddressDescriptions.Contains(ua.Description)).ToList();

            // Si hay nuevas direcciones que no existen en la base de datos
            //if (newAddresses.Any())
            //{
            //foreach (var address in listAddresses)
            //{
                // Crear una nueva UserAddress si no existe
                var newUserAddress = new UserAddress
                {
                    FInsert = DateTime.Now,
                    UserName = "asd",  // Asegúrate de que este campo tiene sentido en tu contexto
                    FUpdate = DateTime.Now,
                    UserNameUpdate = "asd",  // Asegúrate de que este campo tiene sentido en tu contexto
                    Code = "asd",  // Asegúrate de que este campo tiene sentido en tu contexto
                    UserID = new Guid("08dccf82-fdd3-4dd3-8d76-1ba36bd0594f"),
                    StreetID = new Guid("08dcbfed-afd6-4c1d-8abd-51599b6d10c4"),
                    CoordinatesID = new Guid("08dcbfee-598c-436c-821e-4eeea81ca128"),
                };

                _context.UserAddresses.Add(newUserAddress);
                //existingAddresses.Add(newUserAddress); // Añadir la nueva dirección a la lista de resultados
            //}

            // Guardar los cambios en la base de datos
            _context.SaveChanges();
            //}

            return existingAddresses;
        }

        public UserPerson GetPersonById(Guid id)
        {
            // Realizar la consulta con proyección y relaciones incluidas
            var result = _context.UserPeople
                .Include(up => up.PersonProfessions)    // Incluir la lista de PersonProfessions
                .ThenInclude(pp => pp.Profession)       // Incluir las Profesiones dentro de PersonProfessions

                .Include(up => up.Networks)             // Incluir Networks
                .ThenInclude(pp => pp.NetworkType)      // Incluir NetworkType dentro de Networks

                .Include(up => up.UserAddresses)        // Incluir UserAddresses
                .ThenInclude(ua => ua.Street)           // Incluir Street dentro de UserAddresses

                .Include(up => up.UserAddresses)        // Incluir Coordinates dentro de Street
                .ThenInclude(st => st.Coordinates)

                .AsNoTracking()
                .Where(up => up.Id == id)               // Filtrar por ID
                .Select(up => new UserPerson            // Proyectar solo las propiedades necesarias
                {
                    Id = up.Id,
                    FirstName = up.FirstName,
                    LastName = up.LastName,
                    Birthdate = up.Birthdate,
                    ProfileImage = up.ProfileImage,
                    ShortDescription = up.ShortDescription,
                    LongDescription = up.LongDescription,
                    ProfileTitle = up.ProfileTitle,
                    Gender = up.Gender,
                    PersonProfessions = up.PersonProfessions, // Incluyendo PersonProfessions
                    Networks = up.Networks,                   // Incluyendo Networks
                    UserAddresses = up.UserAddresses,         // Incluyendo UserAddresses
                    Tags = up.PersonTags.Select(pt => pt.Tag.TagName).ToList(), // Extraer solo TagName
                    Professions = up.PersonProfessions.Select(pt => pt.Profession.ProfessionName).ToList(), // Extraer solo TagName
                    NetworkProfiles = new List<NetworkProfile>() // Inicializar NetworkProfiles vacío
                })
                .FirstOrDefault();

            // Comprobar si 'result' es nulo
            if (result == null)
            {
                throw new NullReferenceException("El resultado de la consulta es nulo.");
            }

            // Verificar si UserAddresses contiene datos
            var firstAddress = result.UserAddresses?.FirstOrDefault();
            if (firstAddress != null && firstAddress.Street != null)
            {
                result.AddressProfile = new AddressProfile
                {
                    StreetName = firstAddress.Street.StreetName,
                    StreetNumber = firstAddress.Street.StreetNumber,
                    Floor = firstAddress.Street.Floor,
                    Country = firstAddress.Street.City?.Province?.Country?.CountryName, // Comprobación de nulos para evitar errores
                    Province = firstAddress.Street.City?.Province?.ProvinceName,
                    City = firstAddress.Street.City?.CityName,  // Nombre correcto de la ciudad
                    URLMaps = firstAddress.Coordinates?.GoogleMapsURL // Verificación de nulos para Coordinates
                };
            }
            else
            {
                // Opcional: Manejo cuando no hay dirección
                result.AddressProfile = new AddressProfile();
            }

            // Inicializar NetworkProfiles si es necesario
            if (result.NetworkProfiles == null)
            {
                result.NetworkProfiles = new List<NetworkProfile>();
            }

            // Verificar si Networks no es nulo
            var networks = result.Networks;
            if (networks != null)
            {
                foreach (var item in networks)
                {
                    // Verificar que item y sus propiedades no sean nulas
                    if (item != null && item.NetworkType != null && item.URL != null)
                    {
                        result.NetworkProfiles.Add(new NetworkProfile
                        {
                            ButtonColor = "red", // Este color puede ser dinámico según lo que necesites
                            Title = item.Description ?? "No Title",  // Manejar el caso donde la descripción sea nula
                            PhoneNumber = item.PhoneNumber ?? "No Title",  // Manejar el caso donde la descripción sea nula
                            UrlIcon = item.NetworkType.IconURL ?? "", // Manejar el caso donde IconURL sea nulo
                            UrlNetwork = item.URL // Ya verificado que no es nulo
                        });
                    }
                }
            }

            return result;
        }






    }
}
