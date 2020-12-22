using System;
using Store.Domain.Models;

namespace Store.Domain
{
    public class Product : DomainObject
    {
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string FullDescription { get; set; }
        public double Cost { get; set; }
        public int Count { get; set; }
        public Guid? VendorId { get; set; }
        public bool? FreeShipping { get; set; }
        public string ImageSource { get; set; }
        public double Weight { get; set; }
        public double Length { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
    }
}
