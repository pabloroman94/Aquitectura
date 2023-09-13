namespace CustomerApp.Api.Models.SeedWork
{
    public class BaseEntityModel<TPrimaryKey>
    {
        /// <summary>
        /// Identificador unico del registro
        /// </summary>
        public TPrimaryKey Id { get; set; }
    }
}
