using Domain.Entities;
using Domain.Entities.Filters;
using Domain.Interfaces.Aplication;
using Domain.Interfaces.Aplication.SeedWork;
using Domain.Interfaces.Infraestructure.Data.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Aplications
{
    public class MailAplication : BaseCrudStampAplication<Mail, Guid, MailAplicationFilter>,
                                   IBaseCrudStampAplication<Mail, Guid, MailAplicationFilter>,
                                   IMailAplication
    {
        public MailAplication(IBaseRepository<Mail, Guid, MailAplicationFilter> repository) : base(repository)
        {
        }

        public async Task<Mail> PostCustomerMail(Mail customerMail)
        {
            var result = await Create(customerMail);
            return result;
        }
    }
}
