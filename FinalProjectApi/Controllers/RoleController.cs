using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTO;
using Application.Services.Interfaces;
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
        // [HttpPost]
        // public async Task<IActionResult> AddRole([FromBody]RoleRequestModel model)
        // {
        //     if (!ModelState.IsValid)
        //     {
        //         return BadRequest(ModelState);
        //     }
        //     var response = await _roleService.AddRole(model);
        //     if (response.Status)
        //     {
        //         return CreatedAtAction(nameof(AddRole), new{name = response.Data.RoleName});
        //     }
        //     return BadRequest(response.Message);
        // }
        [HttpGet("{rolename}")]
        public async Task<IActionResult> GetRole([FromRoute]string roleName)
        {
            var role = await _roleService.GetRole(roleName);
            if (role.Status)return Ok(role);
            return BadRequest(role.Message);
        }
    }
}