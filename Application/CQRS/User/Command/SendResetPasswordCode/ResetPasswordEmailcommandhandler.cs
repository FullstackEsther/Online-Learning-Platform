using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Services.Interfaces;
using Domain.RepositoryInterfaces;
using MediatR;

namespace Application.CQRS.User.Command.ResetPassword
{
    public class ResetPasswordEmailcommandhandler : IRequestHandler<ResetPasswordEmailCommand, bool>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMailService _mailService;

        public ResetPasswordEmailcommandhandler(IUserRepository userRepository, IMailService mailService)
        {
            _userRepository = userRepository;
            _mailService = mailService;
        }
        public async Task<bool> Handle(ResetPasswordEmailCommand request, CancellationToken cancellationToken)
        {
           var user = await  _userRepository.Get(x => x.Username == request.Username);
           if (user == null) return false;
           var code = user.GenerateCode();
           await _userRepository.Save();
          var sendEmail = _mailService.SendCodeToEmail(request.Username,code);
            if(sendEmail)return true;
            return false;
        }
    }
}