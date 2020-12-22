using Prism.Events;
using Prism.Mvvm;
using Store.Domain;
using System.Collections.ObjectModel;
using Store.Domain.Models;
using Store.Domain.Services;

namespace StoreWPF.ViewModel
{
    public class ShoppingCartVM : BindableBase
    {
        readonly IDataService<ShoppingCartItem> _shoppingCartItemService ;
        public ShoppingCartVM( IDataService<ShoppingCartItem> shoppingCartItem)
        {
            _shoppingCartItemService = shoppingCartItem;
            Items = new ObservableCollection<Product>();
        }

        public ObservableCollection<Product> Items { get; set; }
    }
}
