using Domain.Entities.Enums;
using System;

namespace Domain.Entities
{

    // Pensado para tener registro de quien inserto el registro
    public abstract class BaseStampEntity<TPrimaryKey> : BaseEntity<TPrimaryKey>
    {
        private BoolCharEnum _active;

        /// <summary>
        /// Indica si se pago por adelantado
        /// </summary>
        /// <example>Y</example>
        public BoolCharEnum Active
        {
            set
            {
                if (!Enum.IsDefined(value))
                {
                    _active = BoolCharEnum.N;
                }
                else
                {
                    _active = value;
                }
            }
            get
            {
                return !Enum.IsDefined(_active) ? BoolCharEnum.N : _active;
            }
        }

        /// <summary>
        /// Fecha de insercion del registro
        /// </summary>
        public DateTime FInsert { get; set; }


        /// <summary>
        /// Usuario que inserto el registro
        /// </summary>
        public string UserName { get; set; }


        public int Version { get; set; }

        public DateTime? FUpdate { get; set; }

        public string? UserNameUpdate { get; set; }

    }
}
