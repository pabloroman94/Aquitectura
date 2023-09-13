using Application.Aplications.SeedWork;
using Domain.Entities;
using Domain.Interfaces.Aplication;
using Domain.Interfaces.Aplication.SeedWork;
using Domain.Interfaces.Infraestructure.Data;
using Domain.Interfaces.Infraestructure.Data.SeedWork;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Aplications
{


    public class BaseCrudStampAplication<T, TPrimaryKey, TFilters> : BaseStampAplication<T, TPrimaryKey, TFilters>,
                                                                    IBaseCrudStampAplication<T, TPrimaryKey, TFilters>
                                                                              where T : BaseCrudEntity<TPrimaryKey>
                                                                              where TFilters : Filter

    {

        protected readonly string _userName;
        public BaseCrudStampAplication(IBaseRepository<T, TPrimaryKey, TFilters> repository)
           : base(repository)
        {

            _userName = "TEST"; //TODO:Obtener por medio del hhtpcontext o jwt o de otra manera
        }

    }
}
