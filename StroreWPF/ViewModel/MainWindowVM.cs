using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Store.Domain;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Store.Domain.Models;
using Store.Domain.Services;
using Store.EntityFramework;

namespace StoreWPF.ViewModel
{
    public class MainWindowVM : BindableBase
    {

        private readonly IDataService<Product> _productService = new GenericDataService<Product>(new StoreDbContextFactory());
        private readonly IDataService<ShoppingCart> _shoppingCartService = new GenericDataService<ShoppingCart>(new StoreDbContextFactory());
        private readonly IDataService<ShoppingCartItem> _shoppingCartItemService = new GenericDataService<ShoppingCartItem>(new StoreDbContextFactory());

        private ShoppingCart shoppingCart;

        public  MainWindowVM(IEventAggregator eventAggregator)
        {

            _eventAggregator = eventAggregator;
            Products = new ObservableCollection<Product>(_productService.GetAll());
            _eventAggregator.GetEvent<InsertProductEvent>()
                .Subscribe((product) => { Products.Add(product); });
            shoppingCart = CreateShoppingCart();




            AddProductToShoppingCart = new DelegateCommand<Product>(CreateShoppingCartItem);
        }

        private ShoppingCart CreateShoppingCart()
        {
            shoppingCart = new ShoppingCart()
            {
                Id = Guid.NewGuid()
            };
            _shoppingCartService.Insert(shoppingCart);
            return shoppingCart;

        }

        private void CreateShoppingCartItem(Product product)
        {
            var shoppingCartItem = new ShoppingCartItem()
            {
                ProductId = product.Id,
                ShoppingCartId = shoppingCart.Id
            };
            _shoppingCartItemService.Insert(shoppingCartItem);
            _eventAggregator.GetEvent<AddItemToShoppingCartEvent>().Publish(product);
        }

        private IEventAggregator _eventAggregator;

        public ObservableCollection<Product> Products { get; set; }

        public ObservableCollection<ShoppingCartItem> ShoppingCartItems { get; set; }
        public DelegateCommand<Product> AddProductToShoppingCart { get; }
    }
}
