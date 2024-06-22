using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Application.CQRS.Instructor.Command.EditProfile;
using Application.CQRS.Instructor.Query;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinalProjectApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InstructorController : ControllerBase
    {
        private readonly ISender _mediator;
        public InstructorController(ISender mediator)
        {
            _mediator = mediator;
            
        }
        [HttpGet("profile")]
        public async Task<IActionResult> ViewProfile([FromQuery]GetInstructorProfileQuery query)
        {
           var profile = await _mediator.Send(query);
           if (profile.Status) return Ok(profile);
           return BadRequest(profile);
        }
        [HttpPut]
        public async Task<IActionResult> EditProfile(EditProfileCommand command)
        {
            var response =await _mediator.Send(command);
            if (response.Status) return Ok(response);
            return BadRequest(response);
        }
    }
}