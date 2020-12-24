using System;

namespace Store.Domain.Models
{
    public class ShoppingCartItem : DomainObject
    {
        public Guid ShoppingCartId { get; set; }
        public Guid ProductId { get; set; }
    }
}
