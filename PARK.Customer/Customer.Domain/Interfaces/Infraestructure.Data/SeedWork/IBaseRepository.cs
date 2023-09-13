using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces.Infraestructure.Data.SeedWork
{
    public interface IBaseRepository<T, TPrimaryKey, TFilters>
                               where T : BaseEntity<TPrimaryKey>
                               where TFilters : Filter
    {
        IEnumerable<T> Get(TFilters orderValue);

        IEnumerable<T> Get(ISpecification<T> specification = null);

        Task<T> Get(TPrimaryKey id);

        Task Create(T entity);

        void Update(T entity);

        Task Delete(TPrimaryKey id);
    }
}
