using System;
using System.Collections.Generic;
using System.Text;
using Store.Domain;
using Store.Domain.Data;

namespace Store.Services
{
  public  class ShippingMethodService
    {
        private readonly IRepository<ShippingMethod> _shippingMethodRepository;

        public ShippingMethodService(IRepository<ShippingMethod> shippingMethodRepository )
        {
            _shippingMethodRepository = shippingMethodRepository;
        }
        public IEnumerable<ShippingMethod> GetAllShippingMethods()
        {
            return _shippingMethodRepository.GetAll();
        }
    }
}
