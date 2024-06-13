using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.RepositoryInterfaces;
using MediatR;

namespace Application.CQRS.User.Command.CompareSentCode
{
    public class CompareCodeCommandHandler : IRequestHandler<CompareCodeCommand, bool>
    {
        private readonly IUserRepository _userRepository;

        public CompareCodeCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<bool> Handle(CompareCodeCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.Get(x => x.Username == request.Email);
            var generatedCode = user.ResetPasswordCode;
            if (generatedCode == request.Code) return true;
            return false;
        }
    }
}