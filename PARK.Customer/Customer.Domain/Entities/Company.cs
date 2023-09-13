
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Company : Customer
    {
        public string CompanyName { get; set; }
        public string CurrentName { get; set; }
    }
}