using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.RepositoryInterfaces;
using MediatR;

namespace Application.CQRS.User.Command.ResetPassword
{
    public class ResetPasswordCommandHandler : IRequestHandler<ResetPasswordCommand, bool>
    {
        private readonly IUserRepository _userRepository;

        public ResetPasswordCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<bool> Handle(ResetPasswordCommand request, CancellationToken cancellationToken)
        {
            var user = await  _userRepository.Get(x => x.Username == request.UserName);
            user.ForgotPassword(request.Password, request.ConfirmPassword);
            var unitOfWork = await _userRepository.Save();
            if(unitOfWork > 0) return true;
            return false;
        }
    }
}