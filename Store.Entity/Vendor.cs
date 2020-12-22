using System;
using Store.Domain.Models;

namespace Store.Domain
{
    public class Vendor : DomainObject
    {
        public Guid? WarehouseId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Country { get; set; }

    }
}
