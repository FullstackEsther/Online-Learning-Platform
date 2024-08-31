using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.CQRS.Enrollment.Command.Enroll;
using Application.CQRS.Enrollment.Query.GetEnrollments;
using Application.CQRS.Payment.Command;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinalProjectApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EnrollmentController : ControllerBase
    {
        private readonly ISender _mediator;

        public EnrollmentController(ISender mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("enroll")]
        public async Task<IActionResult> EnrollStudent([FromQuery] Guid courseId, [FromQuery] string? trxref = null)
        {
            var command = new StudentEnrollmentCommand(courseId, trxref);
            var response = await _mediator.Send(command);
            if (response.Status) return Ok(response);
            return BadRequest(response);
        }
        [HttpPost("initializepayment/{courseId:guid}")]
        public async Task<IActionResult> InitializePayment([FromRoute] Guid courseId)
        {
            var command = new InitializePaymentCommand(courseId);
            var response = await _mediator.Send(command);
            if (response.Status) return Ok(response.Data.AuthorizationUrl);
            return BadRequest(response);
        }
         [HttpGet]
        public async Task<IActionResult> GetEnrollments()
        {
            var query = new GetEnrollmentQuery();
            var response = await _mediator.Send(query);
            if (response.Status) return Ok(response);
            return BadRequest(response.Message);
        }
    }
}