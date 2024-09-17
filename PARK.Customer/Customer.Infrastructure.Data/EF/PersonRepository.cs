using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Domain.Entities;
using Domain.Interfaces.Infraestructure.Data;
using Infrastructure.Data.EF;

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

                .Include(up =>up.Networks)
                .ThenInclude(pp => pp.NetworkType)
                
                .Include(up =>up.UserAddresses)
                .ThenInclude(ua => ua.Street)           // Incluir Street dentro de UserAddresses
                .Include(up =>up.UserAddresses)
                .ThenInclude(st => st.Coordinates)      // Incluir Coordinates dentro de Street


                .AsNoTracking()                         // Mejora el rendimiento si solo estás leyendo los datos
                .ToList();

            return result;
        }
    }
}
