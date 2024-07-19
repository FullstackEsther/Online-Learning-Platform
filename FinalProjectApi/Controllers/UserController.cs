using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using Application.CQRS.User.Command;
using Application.CQRS.User.Command.AssignRole;
using Application.CQRS.User.Query;
using Application.CQRS.User.Query.Get;
using Application.DTO;
using Application.Services.Interfaces;
using Domain.DomainServices.Interface;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinalProjectApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly ICurrentUser _currentUser;
        private readonly ISender _mediator;

        public UserController(IAuthService authService, ISender mediator)
        {
            _authService = authService;
            _mediator = mediator;
        }

        [HttpPost("assignrole")]
        public async Task<IActionResult> AssignRoleToUser([FromQuery] string roleName)
        {
            var command = new AssignRoleCommand(roleName);
            await _mediator.Send(command);
            return Ok();
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterUserCommand command)
        {
            var response = await _mediator.Send(command);
            if (response.Status)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }
        [HttpGet("user")]
        public async Task<IActionResult> GetUser([FromQuery] GetUserQuery query)
        {
            if (!query.Id.HasValue && string.IsNullOrEmpty(query.UserName))
            {
                return BadRequest("Either UserId or UserName must be provided.");
            }
            var user = await _mediator.Send(query);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpGet("users")]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _mediator.Send(new UsersListQuery());
            if (!users.Status)
            {
                return NotFound(users.Message);
            }
            return Ok(users);
        }
    }
}