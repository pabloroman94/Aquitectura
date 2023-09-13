using Domain.Entities;

namespace Domain.Interfaces.Aplication.SeedWork
{
    public interface IBaseCrudStampAplication<T, TPrimaryKey, TFilters> : IBaseStampAplication<T, TPrimaryKey, TFilters>
                                         where T : BaseCrudEntity<TPrimaryKey>
                                         where TFilters : Filter
    {

    }
}
