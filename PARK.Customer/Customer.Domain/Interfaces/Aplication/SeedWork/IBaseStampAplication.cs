using Domain.Entities;

namespace Domain.Interfaces.Aplication.SeedWork
{
    public interface IBaseStampAplication<T, TPrimaryKey, TFilters> : IBaseAplication<T, TPrimaryKey, TFilters>
                                         where T : BaseStampEntity<TPrimaryKey>
                                         where TFilters : Filter

    {

    }
}
