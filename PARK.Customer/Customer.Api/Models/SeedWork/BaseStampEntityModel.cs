using CustomerApp.Api.Models.SeedWork;
using Domain.Entities.Enums;
using System;

namespace PARK.CustomerApi.Models.SeedWork
{
    public class BaseStampEntityModel<TPrimaryKey> : BaseEntityModel<TPrimaryKey>
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
        /// <example>KiwiSistemas</example>
        public string UserName { get; set; }



        /// <summary>
        /// Indica las versiones que hay de un mismo registro
        /// </summary>
        /// /// <example>1</example>
        public int Version { get; set; }

        public DateTime? FUpdate { get; set; }

        /// <summary>
        /// Usuario que actualizo el registro
        /// </summary>
        /// <example>VFlores</example>
        public string? UserNameUpdate { get; set; }

    }
}
