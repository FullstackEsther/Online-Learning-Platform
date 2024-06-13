using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTO;
using Domain.RepositoryInterfaces;
using MediatR;
using Domain.Entities;

namespace Application.CQRS.User.Command.Register
{
    public class RegisterUserCommandhandler : IRequestHandler<RegisterUserCommand, BaseResponse<UserDto>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;

        public RegisterUserCommandhandler(IUserRepository userRepository, IRoleRepository roleRepository)
        {
            _userRepository = userRepository;
            _roleRepository = roleRepository;
        }
        public async Task<BaseResponse<UserDto>> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var existinguser = _userRepository.Exist(x => x.Username == request.UserName);
            if (existinguser)
            {
                return new BaseResponse<UserDto>
                {
                    Message = "Username already exist",
                    Data = null,
                    Status = false
                };
            }
            var defaultRole = await _roleRepository.Get(x => x.RoleName == "Student");
            var user = new Domain.Entities.User(request.UserName, request.Password);
            user.AddRole(defaultRole);
            var createdUser = await _userRepository.Create(user);
            var unitOfWork = await _userRepository.Save();
            if (unitOfWork > 0)
            {
                return new BaseResponse<UserDto>
                {

                    Message = "User Registered",
                    Status = true,
                    Data = new UserDto
                    {
                        Id = createdUser.Id,
                        roleNames = createdUser.UserRoles.Select(x => x.Role.RoleName).ToList(),
                        UserName = createdUser.Username,
                    }
                };
            }
            return new BaseResponse<UserDto>
            {
                Data = null,
                Message = "User not Created",
                Status = false
            };
        }
    }
}