using System;
using System.Collections.Generic;
using System.Text;
using Prism.Events;
using Store.Domain;

namespace StoreWPF
{
   public class AddItemToShoppingCartEvent : PubSubEvent<Product>
    {

    }
}
