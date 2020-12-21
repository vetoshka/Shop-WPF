using System;
using System.Collections.Generic;
using System.Text;
using Store.Domain;
using Store.Domain.Data;

namespace Store.Services
{
    public class PaymentMethodService
    {
        private readonly IRepository<PaymentMethod> _paymentMethodRepository;

        public PaymentMethodService(IRepository<PaymentMethod> paymentMethodRepository)
        {
            _paymentMethodRepository = paymentMethodRepository;
        }
        public IEnumerable<PaymentMethod> GetAllPaymentMethodsMethods()
        {
            return _paymentMethodRepository.GetAll();
        }
    }
}
