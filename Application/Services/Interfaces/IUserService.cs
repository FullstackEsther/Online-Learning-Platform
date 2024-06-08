using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTO;

namespace Application.Services.Interfaces
{
    public interface IUserService
    {
        Task<BaseResponse<UserDto>> Register(RegisterRequestModel model);
        Task<BaseResponse<UserDto>> GetUser(string UserName);
        Task<BaseResponse<UserDto>> Login(string UserName, string password);
        Task<bool> AssignRoleToUser(string UserName, string RoleName);   
    }
}