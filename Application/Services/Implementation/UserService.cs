using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using Application.DTO;
using Application.Services.Interfaces;
using Domain.Entities;
using Domain.RepositoryInterfaces;

namespace Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<bool> AssignRoleToUser(string userName, string roleName)
        {
            try
            {
                var user = await _userRepository.Get(x => x.Username == userName);
                if (user == null) return false;
                user.AddRole(roleName);
                return true;
            }
            catch (ArgumentException ex)
            {
                throw;
            }

        }

        public async Task<BaseResponse<UserDto>> GetUser(string UserName)
        {
            try
            {
                var user = await _userRepository.Get(x => x.Username == UserName);
                if (user == null)
                {
                    return new BaseResponse<UserDto>
                    {
                        Message = "user doesnot exist",
                        Status = false,
                        Data = null

                    };
                }
                return new BaseResponse<UserDto>
                {
                    Message = "User Found",
                    Status = true,
                    Data = new UserDto
                    {
                        Id = user.Id,
                        roleNames = user.UserRoles.Select(x => x.Role.RoleName).ToList(),
                        UserName = user.Username,
                    }
                };
            }
            catch (ArgumentException ex)
            {
                throw;
            }

        }

        public async Task<BaseResponse<UserDto>> Login(string UserName, string password)
        {
            var user = await _userRepository.Get(x => x.Username == UserName && x.Password == password);
            if (user == null)
            {
                return new BaseResponse<UserDto>
                {
                    Message = "user doesnot exist",
                    Status = false,
                    Data = null

                };
            }
            return new BaseResponse<UserDto>
            {
                Message = "sucessful",
                Status = true,
                Data = new UserDto
                {
                    Id = user.Id,
                    roleNames = user.UserRoles.Select(x => x.Role.RoleName).ToList(),
                    UserName = user.Username,
                }
            };



        }

        public async Task<BaseResponse<UserDto>> Register(RegisterRequestModel model)
        {
            try
            {
                var existinguser = _userRepository.Exist(x => x.Username == model.UserName);
                if (existinguser)
                {
                    return new BaseResponse<UserDto>
                    {
                        Message = "Username already exist",
                        Data = null,
                        Status = false
                    };
                }
                else
                {
                    var user = new User(model.UserName, model.Password);
                    user.AddRole("Student");
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
            catch (ArgumentException ex)
            {
                throw;
            }


        }
    }
}