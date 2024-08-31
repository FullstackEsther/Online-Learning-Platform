using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.CQRS.Enums.Query.GetCourseStatus;
using Application.CQRS.Enums.Query.GetLevels;
using Application.CQRS.Enums.Query.GetQuestionType;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinalProjectApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EnumController : ControllerBase
    {
        private readonly ISender _mediator;
        public EnumController(ISender mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("level")]
        public async Task<IActionResult> GetLevel()
        {
            var query = new GetLevelQuery ();
            var response = await _mediator.Send(query);
            if (response != null) return Ok(response);
            return BadRequest();
        }

        [HttpGet("courseStatus")]
        public async Task<IActionResult> GetCourseStatus()
        {
            var query = new GetCourseStatusQuery();
            var response = await _mediator.Send(query);
            if (response != null) return Ok(response);
            return BadRequest();
        }

          [HttpGet("questiontype")]
        public async Task<IActionResult> GetQuestionType()
        {
            var query = new GetQuestionTypeQuery();
            var response = await _mediator.Send(query);
            if (response != null) return Ok(response);
            return BadRequest();
        }
    }
}