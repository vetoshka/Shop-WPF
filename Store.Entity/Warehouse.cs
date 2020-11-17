using System;
using System.Collections.Generic;
using System.Text;
using Store.Domain;

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
