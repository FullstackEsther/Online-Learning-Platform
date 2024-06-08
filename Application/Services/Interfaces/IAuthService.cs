using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTO;
using Domain.Entities;

namespace Application.Services.Interfaces
{
    public interface IAuthService
    {
        public string GenerateToken(UserDto user);
    }
}