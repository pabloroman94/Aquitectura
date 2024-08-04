using System;

namespace PARK.CustomerApi.Models
{
    public class BaseModel<TPrimaryKey>
    {
        /// <summary>
        /// Identificador unico del registro
        /// </summary>
        /// <example> 432532 </example>
        public TPrimaryKey Id { get; set; }

        /// <summary>
        /// Fecha de insercion del registro
        /// </summary>      
        //public DateTime FInsert { get; set; }

        /// <summary>
        /// Usuario que inserto el registro
        /// </summary>
        ///  <example> RPablo </example>
        public string UserName { get; set; }

        ///
        /// <example> Y </example>
        //public string Active { get; set; }


        /// <summary>
        /// Version del registro
        /// </summary>  
        /// <example> 1 </example>
        public int Version { get; set; }

        /// <summary>
        /// Fecha de actualizacion
        /// </summary>
        public DateTime? FUpdate { get; set; }

        /// <summary>
        /// Usuario que  actualizo por ultima vez el registro
        /// 
        /// </summary>
        /// /// <example> RPablo</example>
        public string? UserNameUpdate { get; set; }
    }
}
