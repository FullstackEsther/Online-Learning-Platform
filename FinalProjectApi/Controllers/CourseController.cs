using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.CQRS.Course.Command;
using Application.CQRS.Course.Command.AddLessonToModule;
using Application.CQRS.Course.Command.AddModuleQuiz;
using Application.CQRS.Course.Command.AddModuleToCourse;
using Application.CQRS.Course.Command.AddOption;
using Application.CQRS.Course.Command.AddQuestion;
using Application.CQRS.Course.Command.DeleteCourse;
using Application.CQRS.Course.Command.DeleteCourseModule;
using Application.CQRS.Course.Command.DeleteLesson;
using Application.CQRS.Course.Command.DeleteOption;
using Application.CQRS.Course.Command.DeleteQuestion;
using Application.CQRS.Course.Command.DeleteQuiz;
using Application.CQRS.Course.Command.UpdateCourseModule;
using Application.CQRS.Course.Command.UpdateModuleLesson;
using Application.CQRS.Course.Query.GetAllCourses;
using Application.CQRS.Course.Query.GetCourse;
using Application.CQRS.Instructor.Command.CreateCourse;
using Application.DTO;
using Domain.Domain.Shared.Enum;
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
        public async Task<IActionResult> CreateCourse([FromForm] CourseRequestModel model)
        {
            // model.DisplayPicture = file;
            var command = new CreateCourseCommand(model);
            var response = await _mediator.Send(command);
            if (response.Status) return Ok(response);
            return BadRequest(model);
        }
        [HttpPut("course")]
        public async Task<IActionResult> UpdateCourse(UpdateCourseCommand command)
        {
            var response = await _mediator.Send(command);
            if (response) return Ok();
            return BadRequest();
        }
        [HttpDelete("{courseId:guid}")]
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

        [HttpPut("module")]
        public async Task<IActionResult> UpdateModule(UpdateCourseModuleCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }
        [HttpPut("lesson")]
        public async Task<IActionResult> UpdateLesson(UpdateModuleLessonCommand command)
        {
            var response = await _mediator.Send(command);
            if (response) return Ok();
            return BadRequest();
        }

        [HttpPost("lesson")]
        public async Task<IActionResult> AddLesson(AddModuleLessonCommand command)
        {
            var response = await _mediator.Send(command);
            if (response.Status) return Ok(response);
            return BadRequest(response.Message);
        }
        [HttpDelete("module/{courseId:guid},{moduleId:guid}")]
        public async Task<IActionResult> DeleteModule([FromRoute] Guid courseId, [FromRoute] Guid moduleId)
        {
            var command = new DeleteCourseModuleCommand(courseId, moduleId);
            await _mediator.Send(command);
            return Ok();
        }
        [HttpDelete("lesson/{moduleId:guid},{lessonId:guid}")]
        public async Task<IActionResult> DeleteLesson([FromRoute] Guid moduleId, [FromRoute] Guid lessonId)
        {
            var command = new DeleteModuleLessonCommand(moduleId, lessonId);
            await _mediator.Send(command);
            return Ok();
        }
        [HttpPost("quiz")]
        public async Task<IActionResult> AddQuiz([FromRoute] Guid moduleId, [FromBody] double duration)
        {
            var command = new AddQuizToModuleCommand(moduleId, duration);
            var response = await _mediator.Send(command);
            if (response.Status) return Ok();
            return BadRequest(response);
        }
        [HttpDelete("quiz/{moduleId:guid}")]
        public async Task<IActionResult> DeleteQuiz([FromRoute] Guid moduleId)
        {
            var command = new DeleteModuleQuizCommand(moduleId);
            await _mediator.Send(command);
            return Ok();
        }
        [HttpPost("question")]
        public async Task<IActionResult> AddQuestionToQuiz([FromRoute] Guid moduleId, [FromRoute] Guid quizId, string questionText, QuestionType questionType)
        {
            var command = new AddQuizQuestionCommand(questionText, quizId, questionType, moduleId);
            var response = await _mediator.Send(command);
            if (response.Status) return Ok();
            return BadRequest(response);
        }
        [HttpDelete("question/{moduleId:guid},{questionId:guid}")]
        public async Task<IActionResult> DeleteQuestion([FromRoute] Guid moduleId, [FromRoute] Guid questionId)
        {
            var command = new DeleteQuizQuestionCommand(moduleId, questionId);
            await _mediator.Send(command);
            return Ok();
        }
        [HttpPost("option")]
        public async Task<IActionResult> AddOptionToQuestion([FromRoute] Guid moduleId, [FromRoute] Guid questionId, string optionText, bool isCorrect)
        {
            var command = new AddQuestionOptionCommand(questionId, isCorrect, optionText, moduleId);
            var response = await _mediator.Send(command);
            if (response.Status) return Ok();
            return BadRequest(response);
        }
        [HttpDelete("option/{moduleId:guid}")]
        public async Task<IActionResult> RemoveOption([FromRoute] Guid moduleId, [FromRoute] Guid questionId, string text)
        {
            var command = new DeleteQuestionOptionCommand(moduleId, questionId, text);
            await _mediator.Send(command);
            return Ok();
        }
        [HttpGet("{courseId}")]
        public async Task<IActionResult> GetCourseById([FromRoute] Guid courseId)
        {
            var query = new GetCourseByIdQuery(courseId);
            var response = await _mediator.Send(query);
            if (response.Status) return Ok(response);
            return BadRequest(response.Message);
        }

        [HttpGet("courses")]
        public async Task<IActionResult> GetAllCourses()
        {
            var query = new GetAllCoursesQuery();
            var response = await _mediator.Send(query);
            if (response.Status) return Ok(response);
            return BadRequest(response.Message);
        }
    }
}