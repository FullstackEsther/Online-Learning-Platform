using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.DomainServices.Interface
{
    public interface IPaymentManager
    {
        Task<string> InitializePayment( string userEmail, Guid courseId);
        Task<Payment> VerifyPayment(string reference);
    }
}