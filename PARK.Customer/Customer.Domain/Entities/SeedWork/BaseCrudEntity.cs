namespace Domain.Entities
{

    // Pensada para las entidades que solo se deban eliminar de manera LOGICA
    public class BaseCrudEntity<TPrimaryKey> : BaseStampEntity<TPrimaryKey>
    {

        public string Code { get; set; }

    }
}
