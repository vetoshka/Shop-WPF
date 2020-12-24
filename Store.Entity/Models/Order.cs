using System;

namespace Store.Domain.Models
{
    public class Order : DomainObject
    {
       // public Guid AccountId { get; set; }
        public Guid ShippingMethodId { get; set; }
        public Guid ShippingAddressId { get; set; }
        public Guid PaymentMethodId { get; set; }
        public int OrderNumber { get; set; }
        public string OrderStatus { get; set; }
        public string ShippingStatus { get; set; }
        public string PaymentStatus { get; set; }


    }
}
