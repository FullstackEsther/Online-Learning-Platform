using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTO;
using Domain.DomainServices.Interface;
using Domain.RepositoryInterfaces;
using MediatR;

namespace Application.CQRS.Payment.Command
{
    public class InitializePaymentCommandHandler : IRequestHandler<InitializePaymentCommand, BaseResponse<PaymentDto>>
    {
        private readonly IPaymentManager _paymentManager;
        private readonly ICurrentUser _currentUser;

        public InitializePaymentCommandHandler(IPaymentManager paymentManager, ICurrentUser currentUser)
        {
            _paymentManager = paymentManager;
            _currentUser = currentUser;
        }
        public async Task<BaseResponse<PaymentDto>> Handle(InitializePaymentCommand request, CancellationToken cancellationToken)
        {
            var email = "otufeesther@gmail.com";  // _currentUser.GetLoggedInUserEmail();
            var response = await _paymentManager.InitializePayment(request.Amount, email);
            if (response == null)
            {
                return new BaseResponse<PaymentDto>
                {
                    Data = null,
                    Status = false,
                    Message = "Couldn't initialize payment"
                };
            }
            return new BaseResponse<PaymentDto>
            {
                Status = true,
                Message = "Initialized",
                Data = new PaymentDto
                {
                    Amount = response.Amount,
                    Email = response.Email,
                    Status = response.Status,
                    TrxRef = response.TrxRef
                }
            };
        }
    }
}