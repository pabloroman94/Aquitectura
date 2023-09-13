namespace Domain.Entities
{
    public abstract class BaseEntity<TPrimaryKey>
    {
        /// <summary>
        /// Identificador unico del registro
        /// </summary>
        public TPrimaryKey Id { get; set; }

    }
}
