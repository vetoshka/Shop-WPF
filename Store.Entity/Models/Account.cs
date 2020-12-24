using System;
using System.Collections.Generic;

namespace Store.Domain.Models
{
    public class Account : DomainObject
    {
        public virtual User User { get; set; }
        public Guid AddressId { get; set; }
        public virtual IEnumerable<Address> Addresses { get; set; } = new List<Address>();
        public Guid OrderId { get; set; }
        public virtual IEnumerable<Order> Orders { get; set; } = new List<Order>();
    }
}
