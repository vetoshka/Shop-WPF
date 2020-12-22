using System;
using System.Collections.Generic;
using Store.Domain.Models;

namespace Store.Domain
{
    public class ShoppingCart :DomainObject
    {
        public Guid? CustomerId { get; set; }

        private ICollection<ShoppingCartItem> _shoppingCartItems;
        public virtual ICollection<ShoppingCartItem> ShoppingCartItems
        {
            get { return _shoppingCartItems ??= new List<ShoppingCartItem>(); }
            protected set => _shoppingCartItems = value;
        }


    }
}
