using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTO;
using Domain.RepositoryInterfaces;
using MediatR;
using Org.BouncyCastle.Math.EC.Rfc7748;

namespace Application.CQRS.User.Query.Get
{
    public class GetUserQueryHandler : IRequestHandler<GetUserQuery, BaseResponse<UserDto>>
    {
        private readonly IUserRepository _userRepository;

        public GetUserQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<BaseResponse<UserDto?>> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.Get(x => x.Id == request.Id || x.Username == request.UserName);
            if (user == null)
            {
                return new BaseResponse<UserDto?>
                {
                    Status = false,
                    Data = null,
                    Message = "Not Found"
                };
            }
            return new BaseResponse<UserDto?>
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