using Prism.Commands;
using Prism.Mvvm;
using Store.Domain;
using Store.Domain.Models;
using Store.Domain.Services;
using Store.EntityFramework;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace StoreWPF.ViewModel
{
    public class OrderVM : BindableBase
    {
        private readonly IDataService<Order> _orderService = new GenericDataService<Order>(new StoreDbContextFactory());
        private readonly IDataService<Address> _addressService = new GenericDataService<Address>(new StoreDbContextFactory());
        private readonly IDataService<ShippingMethod> _shippingMethodService = new GenericDataService<ShippingMethod>(new StoreDbContextFactory());
        private readonly IDataService<PaymentMethod> _paymentMethodService = new GenericDataService<PaymentMethod>(new StoreDbContextFactory());
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

        public OrderVM()
        {

            ShippingMethods = new ObservableCollection<ShippingMethod>(_shippingMethodService.GetAll());
            PaymentMethods = new ObservableCollection<PaymentMethod>(_paymentMethodService.GetAll());
            AddOrder = new DelegateCommand(CreateOrder);

        }

        private void CreateOrder()
        {
            Address address = new Address()
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
            Order order = new Order()
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
