using System;
using System.Collections.Generic;
using System.Text;

namespace Store.Domain
{
  public  class ShippingMethod
    {
        public Guid ShippingMethodId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
