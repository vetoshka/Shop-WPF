using Prism.Events;
using Store.Domain.Models;

namespace StoreWPF
{
    public class AddItemToShoppingCartEvent : PubSubEvent<Product>
    {

    }
}
