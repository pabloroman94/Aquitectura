using Domain.Entities;
using Domain.Interfaces.Aplication.SeedWork;
using Domain.Interfaces.Infraestructure.Data.SeedWork;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Aplications
{
    public class BaseAplication<T, TPrimaryKey, TFilters> : IBaseAplication<T, TPrimaryKey, TFilters> where T : BaseEntity<TPrimaryKey> where TFilters : Filter
    {
        protected readonly IBaseRepository<T, TPrimaryKey, TFilters> _repositorio;
        public BaseAplication(IBaseRepository<T, TPrimaryKey, TFilters> repositorio)
        {
            _repositorio = repositorio;
        }

        public virtual IEnumerable<T> Get(TFilters filter)
        {
            return _repositorio.Get(filter);
        }

        public virtual Task<T> Get(TPrimaryKey id)
        {
            return _repositorio.Get(id);
        }

        public virtual async ValueTask<T> Create(T entity)
        {
            await _repositorio.Create(entity);

            return await _repositorio.Get(entity.Id);
        }

        public virtual async ValueTask<T> Update(T entity)
        {
            _repositorio.Update(entity);

            return await _repositorio.Get(entity.Id);
        }

        public virtual async Task Delete(TPrimaryKey id)
        {
            await _repositorio.Delete(id);
        }


    }
}

