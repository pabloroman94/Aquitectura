using System.Collections.Generic;

namespace Customer.Api.Models
{
    public class CompanyModel : CustomerModel
    {
        public string CompanyName { get; set; }
        public string CurrentName { get; set; }
    }
}
