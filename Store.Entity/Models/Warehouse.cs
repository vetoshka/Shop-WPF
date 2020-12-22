namespace Store.Domain.Models
{
    public class Warehouse:DomainObject
    {
        public string Name { get; set; }
        public string Country { get; set; }
        public string City { get; set; }

    }
}
