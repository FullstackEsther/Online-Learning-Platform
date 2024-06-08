using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using Application.DTO;
using Application.Services.Interfaces;
using Domain.Entities;
using Domain.RepositoryInterfaces;
using Microsoft.AspNetCore.Http;

namespace Application.Services.Implementation
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;

        public RoleService(IRoleRepository roleRepository, IHttpContextAccessor httpContextAccessor)
        {
            _roleRepository = roleRepository;
        }

        public async Task<BaseResponse<RoleDto>> AddRole(RoleRequestModel model)
        {
            var checkRole = _roleRepository.Exist(x => x.RoleName == model.RoleName);
            if (checkRole)
            {
                return new BaseResponse<RoleDto>
                {
                     Data = null,
                      Message = "Role already exist",
                       Status = false
                };
            }
            var role = new Role(model.RoleName)
            {
                 Description = model.Description,
            };
           var createdRole = await _roleRepository.Create(role);
           var unitOfWork =  await _roleRepository.Save();
           if (unitOfWork > 0)
           {
                return new BaseResponse<RoleDto>
                {
                     Data = new RoleDto
                     {
                         RoleId = createdRole.Id,
                          RoleName = createdRole.RoleName
                     },
                      Message = "Successful",
                       Status = true
                };
           }
           return new BaseResponse<RoleDto>
           {
             Data = null,
              Message = "Not created",
               Status = false
           };
        }

        public async Task<BaseResponse<IEnumerable<RoleDto>>> GetAllRoles()
        {
            var roles = await _roleRepository.GetAll();
            if (roles.Any())
            {
                return new BaseResponse<IEnumerable<RoleDto>>
                {
                    Status = true,
                    Message = "Successful",
                    Data = roles.Select(x => new RoleDto
                    {
                        RoleId = x.Id,
                        RoleName = x.RoleName
                    }).ToList()
                };
            }
            return new BaseResponse<IEnumerable<RoleDto>>
            {
                Data = null,
                Message = "No Roles available",
                Status = false
            };
        }

        public async Task<BaseResponse<RoleDto>> GetRole(string roleName)
        {
            var getRole = await _roleRepository.Get(x => x.RoleName == roleName);
            if (getRole != null)
            {
                return new BaseResponse<RoleDto>
                {
                    Status = true,
                    Message = "Sucessful",
                    Data = new RoleDto
                    {
                        RoleId = getRole.Id,
                        RoleName = getRole.RoleName
                    }
                };
            }
            return new BaseResponse<RoleDto>
            {
                Data = null,
                Message = "Role not Found",
                Status = false
            };
        }

    }
}