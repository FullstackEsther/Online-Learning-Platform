using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.DomainServices.Interface;
using Domain.RepositoryInterfaces;
using MediatR;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Application.CQRS.User.Command.AssignRole
{
    public class AssignRoleCommandHandler : IRequestHandler<AssignRoleCommand>
    {
        private readonly ICurrentUser _currentUser;
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;

        public AssignRoleCommandHandler(ICurrentUser currentUser, IUserRepository userRepository,IRoleRepository roleRepository)
        {
            _currentUser = currentUser;
            _userRepository = userRepository;
            _roleRepository = roleRepository;
        }
        public async Task Handle(AssignRoleCommand request, CancellationToken cancellationToken)
        {
            var role = await _roleRepository.Get(x => x.RoleName == request.RoleName) ?? throw new ArgumentException("Role doesnot exist");
            var userEmail = "otufeesther@gmail.com";//_currentUser.GetLoggedInUserEmail();
            var user = await _userRepository.Get(x => x.Username == userEmail);
            var userRole = user.AddRole(user,role);
            await _userRepository.AddUserRole(userRole);
           await _userRepository.Save();
        }
    }
}