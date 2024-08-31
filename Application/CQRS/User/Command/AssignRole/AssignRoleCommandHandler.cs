using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Application.DTO;
using Domain.DomainServices.Interface;
using Domain.RepositoryInterfaces;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Application.CQRS.User.Command.AssignRole
{
    public record AssignRoleCommandHandler : IRequestHandler<AssignRoleCommand, BaseResponse<UserDto>>
    {
        private readonly ICurrentUser _currentUser;
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly IStudentRepository _studentRepository;

        public AssignRoleCommandHandler(ICurrentUser currentUser, IUserRepository userRepository, IRoleRepository roleRepository,IStudentRepository studentRepository)
        {
            _currentUser = currentUser;
            _userRepository = userRepository;
            _roleRepository = roleRepository;
            _studentRepository = studentRepository;
        }

        public async Task<BaseResponse<UserDto>> Handle(AssignRoleCommand request, CancellationToken cancellationToken)
        {
            var role = await _roleRepository.Get(x => x.RoleName == request.RoleName) ?? throw new ArgumentException("Role doesnot exist");
            var userEmail = _currentUser.GetLoggedInUserEmail();
            var user = await _userRepository.Get(x => x.Username == userEmail);
            var userRole = user.AddRole(user, role);
            var addRole = await _userRepository.AddUserRole(userRole);
            if (request.RoleName == "Student")
            {
                var profilePictureUrl = string.Empty;
                var student = new Domain.Entities.Student()
                {
                    Email = userEmail,
                    Biography = "",
                    FirstName = "",
                    LastName = "",
                    ProfilePicture = profilePictureUrl,
                };
                student.CreateDetails(userEmail, DateTime.UtcNow);
                await _studentRepository.Create(student);
            }
            if (await _userRepository.Save() > 0)
            {
                var addedUser = await _userRepository.Get(x => x.Id == addRole.UserId);
                return new BaseResponse<UserDto>
                {
                    Message = "Successful",
                    Status = true,
                    Data = new UserDto
                    {
                        Id = addedUser.Id,
                        roleNames = addedUser.UserRoles.Select(x => x.Role.RoleName).ToList(),
                        UserName = addedUser.Username
                    }
                };
            }
            return new BaseResponse<UserDto>
            {
                Data = null,
                Message = "Failed",
                Status = false
            };
        }
    }
}