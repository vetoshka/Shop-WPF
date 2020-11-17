using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Store.Domain;
using Store.Domain.Data;
using Store.Services;

namespace StoreWPF.ViewModel
{
   public class MainWindowVM : BindableBase

   {
       protected readonly IEventAggregator _eventAggregator;
        private readonly ProductService productService = new ProductService(new Repository<Product>(new DBContext()));
        private readonly ShoppingCartService shoppingCartService = new ShoppingCartService(new Repository<ShoppingCart>(new DBContext()));
        private readonly ShoppingCartItemService shoppingCartItemService = new ShoppingCartItemService(new Repository<ShoppingCartItem>(new DBContext()));

        private ShoppingCart shoppingCart;
        public MainWindowVM(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            Products = new ObservableCollection<Product>(productService.GetAllProducts());
            _eventAggregator.GetEvent<InsertProductEvent>()
                .Subscribe((product) => { Products.Add(product);});
             shoppingCart=CreateShoppingCart();
            
      

            AddProductToShoppingCart = new DelegateCommand<Product>(CreateShoppingCartItem);
        }

        private ShoppingCart CreateShoppingCart()
        {
            shoppingCart = new ShoppingCart()
            {
                ShoppingCartId = Guid.NewGuid()
            };
            shoppingCartService.InsertShoppingCart(shoppingCart);
            return shoppingCart;

        }

        private void CreateShoppingCartItem(Product product)
        {
            var shoppingCartItem = new ShoppingCartItem()
            {
                ProductId = product.ProductId,
                ShoppingCartId = shoppingCart.ShoppingCartId
            };
            shoppingCartItemService.InsertShoppingCartItem(shoppingCartItem);
            _eventAggregator.GetEvent<AddItemToShoppingCartEvent>().Publish(product);
        }
        public ObservableCollection<Product> Products { get; set; }
        public DelegateCommand<Product> AddProductToShoppingCart { get; }
    }
}
