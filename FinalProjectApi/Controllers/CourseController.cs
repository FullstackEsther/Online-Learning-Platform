using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.CQRS.Course.Command;
using Application.CQRS.Course.Command.AddModuleToCourse;
using Application.CQRS.Course.Command.DeleteCourse;
using Application.CQRS.Course.Command.UpdateCourseModule;
using Application.CQRS.Instructor.Command.CreateCourse;
using Application.DTO;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinalProjectApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CourseController : ControllerBase
    {
        private readonly ISender _mediator;
        public CourseController(ISender mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateCourse(CreateCourseCommand command)
        {
            var response = await _mediator.Send(command);
            if (response.Status) return Ok(response);
            return BadRequest(response);
        }
        [HttpPut("update")]
        public async Task<IActionResult> UpdateCourse(UpdateCourseCommand command)
        {
            var response = await _mediator.Send(command);
            if (response) return Ok();
            return BadRequest();
        }
        [HttpPost("delete/{courseId:guid}")]
        public async Task<IActionResult> DeleteCourse([FromRoute] Guid courseId)
        {
            var command = new DeleteCourseCommand(courseId);
            await _mediator.Send(command);
            return Ok();
        }
        [HttpPost("module")]
        public async Task<IActionResult> AddModule(AddModuleCommand command)
        {
           var response = await _mediator.Send(command);
           if (response.Status) return Ok(response);
           return BadRequest(response.Message);
        }

         [HttpPut("updatemodule")]
        public async Task<IActionResult> Update(UpdateCourseModuleCommand command)
        {
            await _mediator.Send(command);
           return Ok();
        }

    }
}