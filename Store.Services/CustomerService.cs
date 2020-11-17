using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Store.Domain;
using Store.Domain.Data;

namespace Store.Services
{
   public class CustomerService
    {
        private readonly IRepository<Customer> _customerRepository;

        public CustomerService(IRepository<Customer> customerRepository)
        {
            _customerRepository = customerRepository;
        }
        public IEnumerable<Customer> GetAllCustomers()
        {
            return _customerRepository.GetAll().ToList();
        }

        public void InsertCustomer (Customer customer)
        {
            if (customer == null)
                throw new ArgumentNullException(nameof(Customer));
            _customerRepository.Insert(customer);

        }

        public void DeleteCustomer(Customer customer)
        {
            if (customer == null)
                throw new ArgumentNullException(nameof(Customer));
            _customerRepository.Delete(customer);

        }

        public Customer GetCustomerById(Guid id)
        {
            return _customerRepository.GetById(id);
        }
    }
}
