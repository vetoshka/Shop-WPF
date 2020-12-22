using System;
using System.Collections.Generic;
using System.Text;

namespace Store.Domain.Models
{
   public class Account: DomainObject
    {
        public virtual User AccountHolder { get; set; }
        public Guid AddressId { get; set; }
        public virtual IEnumerable<Address> Addresses { get; set; } = new List<Address>();
    }
}
