using System;
using Store.Domain.Models;

namespace Store.Domain
{
    public class Order : DomainObject
    {
        public Guid ShoppingCartId { get; set; }

        public virtual ShoppingCart ShoppingCart { get; set; }
        public Guid ShippingMethodId { get; set; }
        public Guid ShippingAddressId { get; set; }
        public Guid PaymentMethodId { get; set; }
        public Guid CustomerId { get; set; }
        public int OrderNumber { get; set; }
        public string OrderStatus { get; set; }
        public string ShippingStatus { get; set; }
        public string PaymentStatus { get; set; }


    }
}
