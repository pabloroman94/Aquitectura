using Domain.Entities.Enums;
using System;

namespace Infrastructure.Data.Dapper.Entities.SeedWork
{
    public class BaseStampDataEntity<TPrimaryKey> : BaseDataEntity<TPrimaryKey>
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
