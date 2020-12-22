using System;
using Store.Domain.Models;

namespace Store.Domain
{
    public class ShoppingCartItem: DomainObject
    {
        public Guid ShoppingCartId { get; set; }
        public Guid ProductId { get; set; }
    }
}
