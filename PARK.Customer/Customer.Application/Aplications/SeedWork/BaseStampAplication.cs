using Domain.Entities;
using Domain.Entities.Enums;
using Domain.Interfaces.Aplication.SeedWork;
using Domain.Interfaces.Infraestructure.Data.SeedWork;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Aplications.SeedWork
{
    public class BaseStampAplication<T, TPrimaryKey, TFilters> : BaseAplication<T, TPrimaryKey, TFilters>,
                                                                 IBaseStampAplication<T, TPrimaryKey, TFilters>
                                                                  where T : BaseStampEntity<TPrimaryKey>
                                                                  where TFilters : Filter

    {
        protected readonly string _userName;
        public BaseStampAplication(IBaseRepository<T, TPrimaryKey, TFilters> repository)
           : base(repository)
        {
            _userName = "TEST"; //TODO:Obtener por medio del hhtpcontext o jwt o de otra manera
        }
        public override async ValueTask<T> Create(T entity)
        {
            entity.FInsert = DateTime.Now;
            entity.UserName = entity.UserName ?? _userName;
            entity.Version = 1;
            entity.Active = BoolCharEnum.Y;

            return await base.Create(entity);
        }


        public override async ValueTask<T> Update(T entity)
        {
            var updateEntity = await base.Get(entity.Id);


            if (entity.Equals(updateEntity))
                throw new KeyNotFoundException($"El registro no sufrio cambios");

            entity.Version = updateEntity.Version++;
            entity.Active = BoolCharEnum.Y;
            entity.FInsert = DateTime.Now;
            entity.UserName = _userName;
            entity.Id = default(TPrimaryKey);
            await Create(entity);

            await Delete(updateEntity.Id);


            return await base.Get(entity.Id);
        }

        /// <summary>
        ///  Baja logica 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public override async Task Delete(TPrimaryKey id)
        {
            var updateEntity = await base.Get(id);

            if (updateEntity == null)
                throw new KeyNotFoundException($"No existe el id {id}");

            updateEntity.Active = BoolCharEnum.N;
            updateEntity.FUpdate = DateTime.Now;
            updateEntity.UserNameUpdate = _userName;

            base.Update(updateEntity);
        }
    }
}
