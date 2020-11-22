using System;

namespace Store.Domain
{
   public class Vendor
    {
        public Guid VendorId { get; set; }
        public Guid?  WarehouseId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Country { get; set; }

    }
}
