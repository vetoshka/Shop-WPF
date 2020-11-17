using System;
using System.Collections.Generic;
using System.Linq;
using Store.Domain;
using Store.Domain.Data;

namespace Store.Services
{
    public class ProductService 
    {
        private readonly IRepository<Product> _productRepository;

        public ProductService(IRepository<Product> productRepository)
        {
            _productRepository = productRepository;
        }
        public IList<Product> GetAllProducts()
        {
            return _productRepository.GetAll().ToList();
        }

        public void InsertProduct(Product product)
        {
            if (product == null)
                throw new ArgumentNullException(nameof(Product));
            _productRepository.Insert(product);
            
        }

        public void DeleteProduct(Product product)
        {
            if (product == null)
                throw new ArgumentNullException(nameof(Product));
            _productRepository.Delete(product);
            
        }

        public Product GetProductById(Guid id)
        {
            return _productRepository.GetById(id);
        }
        
    }
}
