using Domain.Entities;
using Domain.Entities.Filters;
using Domain.Interfaces.Aplication;
using Domain.Interfaces.Aplication.SeedWork;
using Domain.Interfaces.Infraestructure.Data.SeedWork;
using System;

namespace Application.Aplications
{
    public class UserPhotoAplication : BaseCrudStampAplication<UserPhoto, Guid, UserPhotoFilter>,
                                   IBaseCrudStampAplication<UserPhoto, Guid, UserPhotoFilter>,
                                   IUserPhotoAplication
    {
        public UserPhotoAplication(IBaseRepository<UserPhoto, Guid, UserPhotoFilter> repository) : base(repository)
        {
        }
    }
}
