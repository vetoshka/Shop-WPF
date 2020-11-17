using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Prism.Events;
using Store.Domain;

namespace StoreWPF
{
   public class MakeOrderEvent : PubSubEvent<ObservableCollection<Product>>
    {
    }
}
