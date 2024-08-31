using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.CQRS.Instructor.Command.EditProfile;
using Application.CQRS.Student.Command.CreateProfile;
using Application.CQRS.Student.Command.EditProfile;
using Application.CQRS.Student.Command.UpdateProfilePicture;
using Application.CQRS.Student.Query.ViewProfile;
using Application.CQRS.Student.Query.ViewResults;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinalProjectApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "Student")]
    public class StudentController : ControllerBase
    {
        private readonly ISender _mediator;

        public StudentController(ISender mediator)
        {
            _mediator = mediator;
        }
        // [HttpPost("profile")]
        // public async Task<IActionResult> CreateProfile([FromForm] CreateProfileCommand command)
        // {
        //     var response = await _mediator.Send(command);
        //     if (response.Status) return Ok(response);
        //     return BadRequest(response);
        // }
        [HttpPut("profile")]
        public async Task<IActionResult> UpdateProfile(EditStudentProfileCommand command)
        {
            var response = await _mediator.Send(command);
            if (response.Status) return Ok(response);
            return BadRequest(response);
        }

        [HttpPut("profilepicture")]
        public async Task<IActionResult> UpdateProfilePicture([FromForm] UpdateProfilePictureCommand command)
        {
            var response = await _mediator.Send(command);
            if (response.Status) return Ok(response);
            return BadRequest(response);
        }
        [HttpGet]
        public async Task<IActionResult> GetProfilePicture()
        {
            var query = new GetStudentProfileQuery();
            var response = await _mediator.Send(query);
            if (response.Status) return Ok(response);
            return BadRequest(response);
        }

         [HttpGet("results")]
        public async Task<IActionResult> GetStudentResults()
        {
            var query = new ViewResultsQuery();
            var response = await _mediator.Send(query);
            if (response.Status) return Ok(response);
            return BadRequest(response);
        }
    }
}