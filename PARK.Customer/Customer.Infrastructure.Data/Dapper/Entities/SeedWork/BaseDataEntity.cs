namespace Infrastructure.Data.Dapper.Entities.SeedWork
{
    public class BaseDataEntity<TPrimaryKey>
    {
        /// <summary>
        /// Identificador unico del registro
        /// </summary>
        public TPrimaryKey Id { get; set; }
    }
}
