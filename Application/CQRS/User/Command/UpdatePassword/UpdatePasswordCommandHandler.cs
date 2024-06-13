using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.DomainServices.Interface;
using Domain.RepositoryInterfaces;
using MediatR;

namespace Application.CQRS.User.Command.UpdatePassword
{
    public class UpdatePasswordCommandHandler : IRequestHandler<UpdatePasswordCommand, bool>
    {
        private readonly ICurrentUser _currentUser;
        private readonly IUserRepository _userRepository;

        public UpdatePasswordCommandHandler(ICurrentUser currentUser, IUserRepository userRepository)
        {
            _currentUser = currentUser;
            _userRepository = userRepository;
        }
        public async Task<bool> Handle(UpdatePasswordCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.Get(x => x.Username == _currentUser.GetLoggedInUserEmail()) ?? throw new ArgumentException("User doesn't exist");
            user.ChangePassword(request.NewPassword, request.OldPassword);
            _userRepository.Update(user);
           var untOfWork =  await _userRepository.Save();
           if (untOfWork> 0) return true;
            return false;
        }
    }
}