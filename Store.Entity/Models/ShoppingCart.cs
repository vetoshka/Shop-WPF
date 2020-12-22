using System;
using System.Collections.Generic;

namespace Store.Domain.Models
{
    public class ShoppingCart :DomainObject
    {
        public Guid? AccountId { get; set; }

        private ICollection<ShoppingCartItem> _shoppingCartItems;
        public virtual ICollection<ShoppingCartItem> ShoppingCartItems
        {
            get { return _shoppingCartItems ??= new List<ShoppingCartItem>(); }
            protected set => _shoppingCartItems = value;
        }


    }
}
