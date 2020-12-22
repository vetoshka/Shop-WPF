using System;

namespace Store.Domain.Models
{
    public class Vendor : DomainObject
    {
        public Guid? WarehouseId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Country { get; set; }

    }
}
