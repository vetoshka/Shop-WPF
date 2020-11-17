using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Store.Domain;
using Store.Domain.Data;

namespace Store.Services
{
  public  class ShoppingCartItemService
    {
        private readonly IRepository<ShoppingCartItem> _shoppingCartItemRepository;

        public ShoppingCartItemService(IRepository<ShoppingCartItem> shoppingCartItemRepository)
        {
            _shoppingCartItemRepository = shoppingCartItemRepository;
        }
        public IEnumerable<ShoppingCartItem> GetAllShoppingCartItems()
        {
            return _shoppingCartItemRepository.GetAll().ToList();
        }

        public IEnumerable<ShoppingCartItem> GetShoppingCartItemsByShoppingCartId(Guid id)
        {
           return _shoppingCartItemRepository.GetAll().Where(item => item.ShoppingCartId == id);
             
        }
        public void InsertShoppingCartItem(ShoppingCartItem shoppingCartItem)
        {
            if (shoppingCartItem == null)
                throw new ArgumentNullException(nameof(ShoppingCartItem));
            _shoppingCartItemRepository.Insert(shoppingCartItem);

        }

        public void DeleteShoppingCartItem(ShoppingCartItem shoppingCartItem)
        {
            if (shoppingCartItem == null)
                throw new ArgumentNullException(nameof(ShoppingCartItem));
            _shoppingCartItemRepository.Delete(shoppingCartItem);

        }

        public  ShoppingCartItem GetShoppingCartItemById(Guid id)
        {

            return _shoppingCartItemRepository.GetById(id);
        }

        public double GetShoppingCartItemsCost(Guid shoppingCartId)
        {
            var productService= new ProductService(new Repository<Product>(new DBContext()));
            var items = GetShoppingCartItemsByShoppingCartId(shoppingCartId);
            return items.Sum(item => productService.GetProductById(item.ProductId).Cost);
        }
    }
}
