using System;
using System.Collections.Generic;
using System.Text;

namespace Store.Domain
{
   public class ShoppingCart
    {
        public Guid ShoppingCartId { get; set; }
        public Guid? CustomerId { get; set; }

        

    }
}
