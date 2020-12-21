using System;

namespace Store.Domain
{
    public class ShoppingCartItem
    {
        public Guid ShoppingCartItemId { get; set; }
        public Guid ShoppingCartId { get; set; }
        public Guid ProductId { get; set; }
    }
}
