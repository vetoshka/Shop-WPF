using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Store.Domain;
using Store.Domain.Data;

namespace Store.Services
{
   public class VendorService
    {
        private readonly IRepository<Vendor> _vendorRepository;

        public VendorService(IRepository<Vendor> productRepository)
        {
            _vendorRepository = productRepository;
        }
        public IList<Vendor> GetAllVendors()
        {
            return _vendorRepository.GetAll().ToList();
        }

        public void InsertVendor(Vendor vendor)
        {
            if (vendor == null)
                throw new ArgumentNullException(nameof(Vendor));
            _vendorRepository.Insert(vendor);

        }

        public void DeleteVendor(Vendor vendor)
        {
            if (vendor == null)
                throw new ArgumentNullException(nameof(Vendor));
            _vendorRepository.Delete(vendor);

        }

        public Vendor GetVendorById(Guid id)
        {
            return _vendorRepository.GetById(id);
        }
    }
}
