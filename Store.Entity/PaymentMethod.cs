﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Store.Domain
{
   public class PaymentMethod
    {
        public Guid PaymentMethodId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
