using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTO;
using Domain.RepositoryInterfaces;
using MediatR;

namespace Application.CQRS.User.Command
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, BaseResponse<UserDto>>
    {
        private readonly IUserRepository _userRepository;

        public LoginUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<BaseResponse<UserDto>> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.Get(x => x.Username == request.UserName && x.Password == request.Password);
            if (user == null)
            {
                return new BaseResponse<UserDto>
                {
                    Data = null,
                    Message = "Email and Password incorrect",
                    Status = false
                };
            }
            return new BaseResponse<UserDto>
            {
                Status = true,
                Message = "Successful",
                Data = new UserDto
                {
                    Id = user.Id,
                    roleNames = user.UserRoles.Select(x => x.Role.RoleName).ToList(),
                    UserName = user.Username
                }
            };
        }
    }
}