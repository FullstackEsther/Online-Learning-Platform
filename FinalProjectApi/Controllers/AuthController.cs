using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.CQRS.User.Command;
using Application.CQRS.User.Command.CompareSentCode;
using Application.CQRS.User.Command.ResetPassword;
using Application.CQRS.User.Command.UpdatePassword;
using Application.Services.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinalProjectApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly ISender _mediator;
        private readonly IAuthService _authService;

        public AuthController(ISender mediator, IAuthService authService)
        {
            _mediator = mediator;
            _authService = authService;
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginUserCommand command)
        {
            var login = await _mediator.Send(command);
            if (!login.Status)
            {
                return NotFound(login.Message);
            }
            var token = _authService.GenerateToken(login.Data);

            var response = new { Token = token, Role = login.Data.roleNames };
            return Ok(response);
        }
        [Authorize(Roles = "Instructor,Admin,Student")]
        [HttpPut("password")]
        public async Task<IActionResult> UpdatePassword(UpdatePasswordCommand command)
        {
            var update = await _mediator.Send(command);
            if (update)
            {
                return Ok();
            }
            return BadRequest();
        }
        
        [HttpPost("sendCode")]
        public async Task<IActionResult> SendChangePasswordCode(ResetPasswordEmailCommand command)
        {
            var sendEmail = await _mediator.Send(command);
            if (sendEmail) return Ok();
            return BadRequest("Email doesn't esxist");
        }
        [HttpPost("compareCode")]
        public async Task<IActionResult> CompareGeneratedCode(CompareCodeCommand command)
        {
            var compareCode = await _mediator.Send(command);
            if (compareCode) return Ok();
            return BadRequest("Code doesn't match");
        }
        [HttpPost("resetPassword")]
        public async Task<IActionResult> ResetPassword(ResetPasswordCommand command)
        {
            var resetPassword = await _mediator.Send(command);
            if (resetPassword) return Ok();
            return BadRequest();
        }
    }
}