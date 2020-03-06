using System;

namespace DomainModel
{
    public class CustomerSnapshot
    {
        public Guid Id { get; set; }
        public string Address { get; set; }
        public string Name { get; set; }
    }
}