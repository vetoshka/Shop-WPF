using System;

namespace Store.Domain
{
    public class Warehouse
    {
        public Guid WarehouseId { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public string City { get; set; }

    }
}
