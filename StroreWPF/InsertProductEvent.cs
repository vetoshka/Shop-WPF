using Prism.Events;
using Store.Domain;

namespace StoreWPF
{
    public class InsertProductEvent : PubSubEvent<Product>
    {
    }
}
