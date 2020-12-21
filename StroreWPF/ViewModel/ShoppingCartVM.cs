using Prism.Events;
using Prism.Mvvm;
using Store.Domain;
using Store.Domain.Data;
using Store.Services;
using System.Collections.ObjectModel;

namespace StoreWPF.ViewModel
{
    public class ShoppingCartVM : BindableBase
    {
        protected readonly IEventAggregator _eventAggregator;
        readonly ShoppingCartItemService shoppingCartItemService = new ShoppingCartItemService(new Repository<ShoppingCartItem>(new DBContext()));
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
