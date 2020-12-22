using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Store.Domain;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Store.Domain.Services;

namespace StoreWPF.ViewModel
{
    public class MainWindowVM : BindableBase
    {

        private readonly IDataService<Product> _productService;
        private readonly IDataService<ShoppingCart> _shoppingCartService;
        private readonly IDataService<ShoppingCartItem> _shoppingCartItemService;

        private ShoppingCart shoppingCart;

        public  MainWindowVM(IDataService<Product> productService, IDataService<ShoppingCart> shoppingCartService,
            IDataService<ShoppingCartItem> shoppingCartItemService)
        {
            _shoppingCartService = shoppingCartService;
            _productService = productService;
            _shoppingCartItemService = shoppingCartItemService;
            Products = new ObservableCollection<Product>(_productService.GetAll());
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
        }
        public ObservableCollection<Product> Products { get; set; }
        public DelegateCommand<Product> AddProductToShoppingCart { get; }
    }
}
