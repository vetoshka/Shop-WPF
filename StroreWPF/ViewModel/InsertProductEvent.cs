using Prism.Events;
using Store.Domain.Models;

namespace StoreWPF.ViewModel
{
    public class InsertProductEvent : PubSubEvent<Product>
    {

    }
}