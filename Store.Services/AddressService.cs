using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Store.Domain;
using Store.Domain.Data;

namespace Store.Services
{
   public class AddressService
    {
        private readonly IRepository<Address> _addressRepository;

        public AddressService(IRepository<Address> addressRepository)
        {
            _addressRepository = addressRepository;
        }
        public IEnumerable<Address> GetAllAddresses()
        {
            return _addressRepository.GetAll();
        }

        public void InsertAddress(Address address)
        {
            if (address == null)
                throw new ArgumentNullException(nameof(Address));
            _addressRepository.Insert(address);

        }

        public void DeleteAddress(Address address)
        {
            if (address == null)
                throw new ArgumentNullException(nameof(Address));
            _addressRepository.Delete(address);

        }

        public Address GetAddressById(Guid id)
        {
            return _addressRepository.GetById(id);
        }
    }
}
