using System;
using System.Collections.Generic;
using System.Text;
using Prism.Events;
using Store.Domain;
using Store.Domain.Models;

namespace StoreWPF
{
    public class AddItemToShoppingCartEvent : PubSubEvent<Product>
    {

    }
}
