using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTO;
using Application.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinalProjectApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;

        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }
        [Authorize(Roles = "Instructor,Admin,Student")]
        [HttpGet("{roleName}")]
        public async Task<IActionResult> GetRole([FromRoute]string roleName)
        {
            var role = await _roleService.GetRole(roleName);
            if (role.Status)return Ok(role);
            return BadRequest(role.Message);
        }
    }
}