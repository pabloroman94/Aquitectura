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

        public IEnumerable<UserPerson> GetPersonsByFilter()
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
                    ProfileDescription = up.ProfileDescription,
                    Gender = up.Gender,
                    PersonProfessions = up.PersonProfessions, // Incluyendo PersonProfessions
                    Networks = up.Networks,                   // Incluyendo Networks
                    UserAddresses = up.UserAddresses,         // Incluyendo UserAddresses
                    Tags = up.PersonTags.Select(pt => pt.Tag.TagName).ToList(), // Extraer solo TagName
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
