using System;
using System.Collections.Generic;
using System.Text;

namespace Store.Domain
{
   public class ShoppingCartItem
    {
        public Guid ShoppingCartItemId { get; set; }
        public Guid ShoppingCartId { get; set; }
        public Guid ProductId { get; set; }
    }
}
