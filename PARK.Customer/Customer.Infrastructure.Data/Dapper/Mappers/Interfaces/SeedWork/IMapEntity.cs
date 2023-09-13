using System.Collections.Generic;

namespace Infrastructure.Data.Dapper.Mappers.Interfaces
{
    public interface IMapEntity<TDto, TEntity>
    {
        TDto Map(TEntity entity);
        IEnumerable<TDto> Map(IEnumerable<TEntity> entities);
    }
}
