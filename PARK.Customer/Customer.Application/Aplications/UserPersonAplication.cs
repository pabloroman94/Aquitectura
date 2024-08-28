using Domain.Entities;
using Domain.Entities.Filters;
using Domain.Interfaces.Aplication;
using Domain.Interfaces.Aplication.SeedWork;
using Domain.Interfaces.Infraestructure.Data.SeedWork;
using System;
using System.Threading.Tasks;

namespace Application.Aplications
{
    public class UserPersonAplication : BaseCrudStampAplication<UserPerson, Guid, UserPersonFilter>,
                                   IBaseCrudStampAplication<UserPerson, Guid, UserPersonFilter>,
                                   IUserPersonAplication
    {
        public UserPersonAplication(IBaseRepository<UserPerson, Guid, UserPersonFilter> repository) : base(repository)
        {
        }

        public async Task<UserPerson> CreatePerson(UserPerson userPersonRequest)
        {
            if (userPersonRequest == null)
            {
                throw new ArgumentNullException(nameof(userPersonRequest));
            }

            // Aquí puedes realizar cualquier lógica adicional antes de la creación, como validaciones
            userPersonRequest.Code = "123456";
            // Llamar al método base para crear el objeto
            var createdUserPerson = await base.Create(userPersonRequest);

            // Puedes realizar lógica adicional después de la creación si es necesario

            return createdUserPerson;
        }
    }
}
