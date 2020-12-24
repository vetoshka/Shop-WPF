using Prism.Events;
using Store.Domain.Models;
using System.Collections.ObjectModel;

namespace StoreWPF
{
    public class MakeOrderEvent : PubSubEvent<ObservableCollection<Product>>
    {
    }
}
