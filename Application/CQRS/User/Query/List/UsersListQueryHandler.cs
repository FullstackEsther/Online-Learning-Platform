using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTO;
using Domain.RepositoryInterfaces;
using MediatR;

namespace Application.CQRS.User.Query
{
    public class UsersListQueryHandler : IRequestHandler<UsersListQuery, BaseResponse<List<UserDto>>>
    {
        private readonly IUserRepository _userRepository;

        public UsersListQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<BaseResponse<List<UserDto>>> Handle(UsersListQuery request, CancellationToken cancellationToken)
        {
           var users = await _userRepository.GetAll();
           if (!users.Any())
           {
                return new BaseResponse<List<UserDto>> 
                {
                     Status = false,
                      Message = "No user found",
                       Data = null
                };
           }
           return new BaseResponse<List<UserDto>>
           {
             Status = true,
              Message = "successful",
               Data = users.Select(x => new UserDto{
                     Id = x.Id,
                      roleNames = x.UserRoles.Select(x => x.Role.RoleName).ToList(),
                       UserName = x.Username
               }).ToList()
           };
        }

        
    }
}