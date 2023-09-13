using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces.Aplication.SeedWork
{
    public interface IBaseAplication<T, TPrimaryKey, TFilters>
                                     where T : BaseEntity<TPrimaryKey>
                                     where TFilters : Filter
    {
        IEnumerable<T> Get(TFilters orderValue);

        Task<T> Get(TPrimaryKey id);

        ValueTask<T> Create(T entity);

        ValueTask<T> Update(T entity);

        Task Delete(TPrimaryKey id);
    }
}
