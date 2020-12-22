using Prism.Commands;
using Prism.Mvvm;
using Store.Domain;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using Store.Domain.Models;
using Store.Domain.Services;

namespace StoreWPF.ViewModel
{
    public class OrderVM : BindableBase
    {
        private readonly IDataService<Order> _orderService;
        private readonly IDataService<Address> _addressService;
        private readonly IDataService<ShippingMethod> _shippingMethodService;
        private readonly IDataService<PaymentMethod> _paymentMethodService ;
        public ShippingMethod SelectedShippingMethod { get; set; }
        public PaymentMethod SelectedPaymentMethod { get; set; }

        public string FirstName { get; set; }
        public Guid ShoppingCartId { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string HouseNumber { get; set; }
        public string PhoneNumber { get; set; }

        public double ProductCost { get; set; }
        public double ShippingCost { get; set; }

        public double Sum { get; set; }

        public OrderVM( IDataService<Order> orderService, IDataService<Address> addressService, IDataService<ShippingMethod> shippingMethodService,
            IDataService<PaymentMethod> paymentMethodService)
        {
            _paymentMethodService = paymentMethodService;
            _shippingMethodService = shippingMethodService;
            _addressService = addressService;
            _paymentMethodService = paymentMethodService;
            _orderService = orderService;
            ShippingMethods = new ObservableCollection<ShippingMethod>(_shippingMethodService.GetAll());
            PaymentMethods = new ObservableCollection<PaymentMethod>(_paymentMethodService.GetAll());
            AddOrder = new DelegateCommand(CreateOrder);

        }

        private void CreateOrder()
        {
            var address = new Address()
            {
                City = City,
                Email = Email,
                FirstName = FirstName,
                HouseNumber = HouseNumber,
                LastName = LastName,
                PhoneNumber = PhoneNumber,
                Street = Street,
                Id = Guid.NewGuid()
            };
            _addressService.Insert(address);
            var order = new Order()
            {
                OrderNumber = _orderService.GetAll().Count() + 1,
                PaymentMethodId = SelectedPaymentMethod.Id,
                ShippingMethodId = SelectedShippingMethod.Id,
                PaymentStatus = Sum.ToString(),
                ShippingAddressId = address.Id
            };
            _orderService.Insert(order);
        }
        public DelegateCommand AddOrder { get; }
        public ObservableCollection<ShippingMethod> ShippingMethods { get; set; }
        public ObservableCollection<PaymentMethod> PaymentMethods { get; set; }

    }
}
