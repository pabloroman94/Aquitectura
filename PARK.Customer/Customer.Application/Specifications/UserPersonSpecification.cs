using Domain.Entities;
using Domain.Entities.Enums;
using System;
using System.Linq;

namespace Application.Specifications
{
    public class UserPersonSpecification : BaseSpecification<UserPerson>
    {
        public UserPersonSpecification() : base(x => x.Active.Equals(BoolCharEnum.Y))
        {
            // Ordenamos por Id para garantizar consistencia en los resultados
            ApplyOrderBy(x => x.Id);

            // Incluimos PersonTags y accedemos a Tag con ThenInclude
            AddInclude(x => x.PersonTags);
            AddInclude(x => x.PersonTags.Select(pt => pt.Tag));

            // Incluimos Networks y accedemos a NetworkType con ThenInclude
            AddInclude(x => x.Networks);
            AddInclude(x => x.Networks.Select(n => n.NetworkType));

            // Incluimos PersonProfessions y accedemos a Profession con ThenInclude
            AddInclude(x => x.PersonProfessions);
            AddInclude(x => x.PersonProfessions.Select(pp => pp.Profession));

            // Incluimos UserAddresses y accedemos a Coordinates y Street con ThenInclude
            AddInclude(x => x.UserAddresses);
            AddInclude(x => x.UserAddresses.Select(ua => ua.Coordinates));
            AddInclude(x => x.UserAddresses.Select(ua => ua.Street));
        }



        //public UserPersonSpecification(int pageNumber = 0, int pageSize = 0) : base(x => x.Active.Equals(BoolCharEnum.Y))
        //{
        //    ApplyOrderBy(x => x.Id);
        //    //ApplyPaging(pageNumber, pageSize);

        //}
        public UserPersonSpecification(Guid id) : base(x => x.Id.Equals(id) && x.Active.Equals(BoolCharEnum.Y))
        {
            ApplyOrderBy(x => x.Id);
            AddInclude(x => x.PersonTags);
            AddInclude($"{nameof(UserPerson.PersonTags)}.{nameof(PersonTag.Tag)}");
        }
    }
}
