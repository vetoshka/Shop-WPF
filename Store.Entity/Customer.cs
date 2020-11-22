using System;

namespace Store.Domain
{
    public class Customer
    {
        public Guid CustomerId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool FreeShipping { get; set; }
        public bool IsAdministrator { get; set; }
        public Guid? AddressId { get; set; }
         public virtual Address Address { get; set; }
    }
}
