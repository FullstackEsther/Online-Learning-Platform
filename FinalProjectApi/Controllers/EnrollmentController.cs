using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.CQRS.Enrollment.Command.Enroll;
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
        [HttpPost("enroll/{courseId:guid}")]
        public async Task<IActionResult> EnrollStudent([FromRoute] Guid courseId, string reference)
        {
            var command = new StudentEnrollmentCommand(courseId, reference);
            var response = await  _mediator.Send(command);
            if (response.Status)return Ok(response);
            return BadRequest(response);
        }
        [HttpPost("initializepayment")]
        public async Task<IActionResult> InitializePayment(decimal amount)
        {
            var command = new InitializePaymentCommand(amount);
            var response = await  _mediator.Send(command);
            if (response.Status)return Ok(response);
            return BadRequest(response);
        }
    }
}