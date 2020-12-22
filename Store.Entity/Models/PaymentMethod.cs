namespace Store.Domain.Models
{
    public class PaymentMethod: DomainObject
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
