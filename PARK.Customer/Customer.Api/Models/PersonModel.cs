using System;

namespace Customer.Api.Models
{
    public class PersonModel : CustomerModel
    {
        public string Name { get; set; }
        public string Lastname { get; set; }
        public Guid? Gender_id { get; set; }
        public DateTime? Birthday { get; set; }
        public GenderModel? Gender { get; set; }
    }
}
