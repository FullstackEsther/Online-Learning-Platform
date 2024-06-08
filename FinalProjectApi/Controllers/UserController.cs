using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using Application.DTO;
using Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FinalProjectApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IUserService _userService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserController(IAuthService authService, IUserService userService, IHttpContextAccessor httpContextAccessor)
        {
            _authService = authService;
            _userService = userService;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody]RegisterRequestModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
           var response =  await _userService.Register(model);
           if (response.Status)
           {
                return CreatedAtAction(nameof(Register), new { id = response.Data.Id }, response);
           }
           return BadRequest(new{response.Message});
        }
        [HttpPost("token")]
        public async Task<IActionResult> Login([FromBody]LoginRequestModel model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var response = await _userService.Login(model.UserName, model.Password);
            if (!response.Status)
            {
                return NotFound();
            }
            var token = _authService.GenerateToken(response.Data);
            return Ok(token);
        }
        [HttpPost]
        public async Task<IActionResult> AssignRoleToUser([FromRoute]string roleName)
        {
            var user = _httpContextAccessor.HttpContext?.User?.Claims.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Email)?.Value;
            var assigned = await  _userService.AssignRoleToUser(user, roleName);
            if (assigned) return Ok();
            return BadRequest();
        }
    }
}