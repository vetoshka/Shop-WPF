using Store.Domain.Models;

namespace Store.Domain
{
    public class ShippingMethod : DomainObject
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
