using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Application.CQRS.Instructor.Command.EditProfile;
using Application.CQRS.Instructor.Command.EditProfilePicture;
using Application.CQRS.Instructor.Command.UpdateProfile;
using Application.CQRS.Instructor.Query;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinalProjectApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "Instructor")]
    public class InstructorController : ControllerBase
    {
        private readonly ISender _mediator;
        public InstructorController(ISender mediator)
        {
            _mediator = mediator;
            
        }
        [HttpGet]
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
        [HttpPut("profilepicture")]
        public async Task<IActionResult> EditProfilePicture(EditProfilePictureCommand command)
        {
            var response =await _mediator.Send(command);
            if (response.Status) return Ok(response);
            return BadRequest(response);
        }
        [HttpPost]
        public async Task<IActionResult> CreateProfile([FromForm]CreateProfileCommand command)
        {
            var response = await _mediator.Send(command);
            if (response.Status) return Ok(response);
            return BadRequest(response);
        }
    }
}