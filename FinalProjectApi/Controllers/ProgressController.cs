using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.CQRS.UserProgress.AddProgress;
using Application.CQRS.UserProgress.Query.GetUserProgress;
using Application.CQRS.UserProgress.UpdateProgress;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinalProjectApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProgressController : ControllerBase
    {
        private readonly ISender _mediator;

        public ProgressController(ISender mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("{courseId:guid}/{lessonId:guid}")]
        public async Task<IActionResult> AddProgress ([FromRoute] Guid courseId, [FromRoute] Guid lessonId)
        {
            var command = new AddProgressCommand(lessonId, courseId);
            var response = await _mediator.Send(command);
            if (response) return Ok();
            return BadRequest();
        }
         [HttpPut("{courseId:guid}/{lessonId:guid}")]
        public async Task<IActionResult> UpdateProgress ([FromRoute] Guid courseId, [FromRoute] Guid lessonId)
        {
            var command = new UpdateProgressCommand(lessonId, courseId);
            var response = await _mediator.Send(command);
            if (response)
            {
                return Ok(response);
            }
            return BadRequest();
        }
        [HttpGet("{courseId:guid}")]
        public async Task<IActionResult> GetUserProgress ([FromRoute]Guid courseId)
        {
            var command = new UserProgressQuery(courseId);
            var response = await _mediator.Send(command);
            if (response.Status) return Ok(response.Data);
            return BadRequest();
        }
    }
}