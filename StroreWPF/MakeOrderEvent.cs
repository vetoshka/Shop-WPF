using Prism.Events;
using Store.Domain;
using System.Collections.ObjectModel;

namespace StoreWPF
{
    public class MakeOrderEvent : PubSubEvent<ObservableCollection<Product>>
    {
    }
}
