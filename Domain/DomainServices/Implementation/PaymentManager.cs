using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Domain.Shared.Exception;
using Domain.DomainServices.Interface;
using Domain.Entities;
using Domain.RepositoryInterfaces;
using Microsoft.Extensions.Configuration;
using PayStack.Net;

namespace Domain.DomainServices.Implementation
{
    public class PaymentManager : IPaymentManager
    {
        private readonly IConfiguration _configuration;
        private readonly string token;
        private PayStackApi PayStack { get; set; }
        private readonly IPaymentRepository _paymentRepository;
        private readonly ICourseRepository _courseRepository;
        public PaymentManager(IConfiguration configuration, IPaymentRepository paymentRepository, ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
            _configuration = configuration;
            token = _configuration["Payment:PaystackKey"];
            PayStack = new PayStackApi(token);
            _paymentRepository = paymentRepository;
        }

        public async Task<string> InitializePayment(string userEmail, Guid courseId)
        {
            if (userEmail != null && courseId != null)
            {

                var course = await _courseRepository.GetCourse(x => x.Id == courseId) ?? throw new DomainException("Course doesnot exist",404);
                var reference = GeneratetransactionReference();
                TransactionInitializeRequest request = new()
                {
                    AmountInKobo = (int)course.Price * 100,
                    Email = userEmail,
                    Currency = "NGN",
                    Reference = reference,
                    CallbackUrl = $"http://127.0.0.1:5501//RedirectPage/index.html?courseId={courseId}"
                };
                TransactionInitializeResponse response = PayStack.Transactions.Initialize(request);
                if (response.Status)
                {
                    var payment = new Payment()
                    {
                        Amount = request.AmountInKobo,
                        Email = userEmail,
                        TrxRef = request.Reference,
                        Status = false
                    };
                    await _paymentRepository.Create(payment);
                    await _paymentRepository.Save();
                    return response.Data.AuthorizationUrl;
                }
                else
                {
                    throw new DomainException ($"{response.Message}");
                }
            }
            else
            {
                throw new DomainException("Enter a valid email and amount");
            }
        }
        public async Task<Payment> VerifyPayment(string reference)
        {
            TransactionVerifyResponse response = PayStack.Transactions.Verify(reference);
            if (response.Data.Status == "success")
            {
                var transaction = await _paymentRepository.GetPayment(x => x.TrxRef == reference);
                if (transaction != null)
                {
                    transaction.Status = true;
                    return _paymentRepository.Update(transaction);
                }
                else
                {
                    throw new DomainException("Payment doesnot exist");
                }
            }
            else
            {
                throw new DomainException($"{response.Message}");
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