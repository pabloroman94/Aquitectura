using System;

namespace Domain.Entities
{
    public class Person : Customer
    {
        public string Name { get; set; }
        public string Lastname { get; set; }
        public Guid? Gender_id { get; set; }
        public DateTime Birthday { get; set; }
        public Gender Gender { get; set; }
    }
}