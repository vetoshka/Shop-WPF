using System;
using Store.Domain.Models;

namespace Store.Domain
{
    public class Customer:DomainObject
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public bool FreeShipping { get; set; }
        public bool IsAdministrator { get; set; }
        public Guid? AddressId { get; set; }
        public virtual Address Address { get; set; }
    }
}
