
namespace Infrastructure.Data.Dapper.Entities.SeedWork
{
    public class BaseCrudDataEntity<TPrimaryKey> : BaseStampDataEntity<TPrimaryKey>
    {
        public string Code { get; set; }
    }
}
