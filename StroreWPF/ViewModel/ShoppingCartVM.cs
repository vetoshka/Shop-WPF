using Prism.Events;
using Prism.Mvvm;
using Store.Domain;
using System.Collections.ObjectModel;
using Store.Domain.Models;
using Store.Domain.Services;
using Store.EntityFramework;

namespace StoreWPF.ViewModel
{
    public class ShoppingCartVM : BindableBase
    {
        readonly IDataService<ShoppingCartItem> _shoppingCartItemService  = new GenericDataService<ShoppingCartItem>(new StoreDbContextFactory());
        private IEventAggregator _eventAggregator;

        public ShoppingCartVM(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            Items = new ObservableCollection<Product>();
            eventAggregator.GetEvent<AddItemToShoppingCartEvent>()
                .Subscribe((product) =>
                {
                    Items.Add(product);
                });

        }

        public ObservableCollection<Product> Items { get; set; }
    }
}
