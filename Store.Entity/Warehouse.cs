using System;
using Store.Domain.Models;

namespace Store.Domain
{
    public class Warehouse:DomainObject
    {
        public string Name { get; set; }
        public string Country { get; set; }
        public string City { get; set; }

    }
}
