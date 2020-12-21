using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Store.Domain;
using Store.Domain.Data;

namespace Store.Services
{
    public class OrderService
    {
        private readonly IRepository<Order> _orderRepository;

        public OrderService(IRepository<Order> orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public IEnumerable<Order> GetAllOrders()
        {
            return _orderRepository.GetAll();
        }

        public void InsertOrder(Order order)
        {
            if (order == null)
                throw new ArgumentNullException(nameof(Order));
            _orderRepository.Insert(order);

        }

        public void DeleteOrder(Order order)
        {
            if (order == null)
                throw new ArgumentNullException(nameof(Order));
            _orderRepository.Delete(order);

        }

        public Order GetOrderById(Guid id)
        {
            return _orderRepository.GetById(id);
        }
    }
}
