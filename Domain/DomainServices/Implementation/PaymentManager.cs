using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.RepositoryInterfaces;
using Microsoft.Extensions.Configuration;
using PayStack.Net;

namespace Domain.DomainServices.Implementation
{
    public class PaymentManager
    {
        private readonly IConfiguration _configuration;
        private readonly string token;
        private PayStackApi PayStack { get; set; }
        private readonly IPaymentRepository _paymentRepository;
        public PaymentManager(IConfiguration configuration, IPaymentRepository paymentRepository)
        {
            _configuration = configuration;
            token = _configuration["Payment:PaystackKey"];
            PayStack = new PayStackApi(token);
            _paymentRepository = paymentRepository;
        }

        public async Task<Payment> InitializePayment(decimal amount, string userEmail)
        {
            if (userEmail != null && amount != 0)
            {
                TransactionInitializeRequest request = new()
                {
                    AmountInKobo = (int)amount * 100,
                    Email = userEmail,
                    Currency = "NGN",
                    Reference = GeneratetransactionReference(),
                    CallbackUrl = ""
                };
                TransactionInitializeResponse response = PayStack.Transactions.Initialize(request);
                if (response.Status)
                {
                    var payment = new Payment()
                    {
                        Amount = amount,
                        Email = userEmail,
                        TrxRef = request.Reference,
                        Status = false
                    };
                    payment.CreateDetails(userEmail);
                    return await _paymentRepository.Create(payment);
                }
                else
                {
                    throw new ArgumentException($"{response.Message}");
                }
            }
            else
            {
                throw new ArgumentException("Enter a valid email and amount");
            }
        }
        public async Task<Payment> VerifyPayment(string reference)
        {
            TransactionVerifyResponse response = PayStack.Transactions.Verify(reference);
            if (response.Data.Status == "success")
            {
               var transaction =  await _paymentRepository.GetPayment(x => x.TrxRef == reference);
               if (transaction != null)
               {
                    transaction.Status = true;
                   return _paymentRepository.Update(transaction);
               }
               else
               {
                    throw new ArgumentException("Payment doesnot exist");
               }
            }
            else
            {
                throw new ArgumentException($"{response.Message}");
            }
        }

        private string GeneratetransactionReference()
        {
            Random random = new Random();
            long rand = random.Next(100000, 999999999);
            return rand.ToString();
        }
    }
}