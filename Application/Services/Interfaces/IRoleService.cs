using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTO;

namespace Application.Services.Interfaces
{
    public interface IRoleService
    {
        // Task<BaseResponse<RoleDto>> AddRole(RoleRequestModel model);
        Task<BaseResponse<IEnumerable<RoleDto>>> GetAllRoles();
        Task<BaseResponse<RoleDto>> GetRole(string roleName);
    }
}