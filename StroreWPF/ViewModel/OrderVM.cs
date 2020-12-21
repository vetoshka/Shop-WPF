using Prism.Commands;
using Prism.Mvvm;
using Store.Domain;
using Store.Domain.Data;
using Store.Services;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace StoreWPF.ViewModel
{
    public class OrderVM : BindableBase
    {
        private readonly OrderService orderService = new OrderService(new Repository<Order>(new DBContext()));
        private readonly AddressService addressService = new AddressService(new Repository<Address>(new DBContext()));
        private readonly ShippingMethodService shippingMethodService = new ShippingMethodService(new Repository<ShippingMethod>(new DBContext()));
        private readonly PaymentMethodService paymentMethodService = new PaymentMethodService(new Repository<PaymentMethod>(new DBContext()));
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
            ShippingMethods = new ObservableCollection<ShippingMethod>(shippingMethodService.GetAllShippingMethods());
            PaymentMethods = new ObservableCollection<PaymentMethod>(paymentMethodService.GetAllPaymentMethodsMethods());
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
                AddressId = Guid.NewGuid()
            };
            addressService.InsertAddress(address);
            var order = new Order()
            {
                CustomerId = Guid.NewGuid(),
                OrderNumber = orderService.GetAllOrders().Count() + 1,
                PaymentMethodId = SelectedPaymentMethod.PaymentMethodId,
                ShippingMethodId = SelectedShippingMethod.ShippingMethodId,
                PaymentStatus = Sum.ToString(),
                ShippingAddressId = address.AddressId
            };
            orderService.InsertOrder(order);
        }
        public DelegateCommand AddOrder { get; }
        public ObservableCollection<ShippingMethod> ShippingMethods { get; set; }
        public ObservableCollection<PaymentMethod> PaymentMethods { get; set; }

    }
}
