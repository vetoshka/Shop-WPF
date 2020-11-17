using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Store.Domain;
using Store.Domain.Data;

namespace Store.Services
{
 public class ShoppingCartService
    {
        private readonly IRepository<ShoppingCart> _shoppingCartRepository;

        public ShoppingCartService(IRepository<ShoppingCart> shoppingCartRepository)
        {
            _shoppingCartRepository = shoppingCartRepository;
        }
        public IEnumerable<ShoppingCart> GetAllShoppingCarts()
        {
            return _shoppingCartRepository.GetAll().ToList();
        }

        public void InsertShoppingCart(ShoppingCart shoppingCart)
        {
            if (shoppingCart == null)
                throw new ArgumentNullException(nameof(ShoppingCart));
            _shoppingCartRepository.Insert(shoppingCart);

        }

        public void DeleteShoppingCart(ShoppingCart shoppingCart)
        {
            if (shoppingCart == null)
                throw new ArgumentNullException(nameof(ShoppingCart));
            _shoppingCartRepository.Delete(shoppingCart);

        }

        public ShoppingCart GetShoppingCartById(Guid id)
        {
            return _shoppingCartRepository.GetById(id);
        }
    }
}

