using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Prism.Events;
using Store.Domain.Models;

namespace StoreWPF
{
    public class MakeOrderEvent : PubSubEvent<ObservableCollection<Product>>
    {
    }
}
