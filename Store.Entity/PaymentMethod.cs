using System;
using Store.Domain.Models;

namespace Store.Domain
{
    public class PaymentMethod: DomainObject
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
