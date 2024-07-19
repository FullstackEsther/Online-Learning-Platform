using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.DomainServices.Interface
{
    public interface IPaymentManager
    {
        Task<Payment> InitializePayment(decimal amount, string userEmail);
        Task<Payment> VerifyPayment(string reference);
    }
}