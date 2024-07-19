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
using Application.CQRS.Course.Command.AddResult;
using Application.CQRS.Course.Command.DeleteCourse;
using Application.CQRS.Course.Command.DeleteCourseModule;
using Application.CQRS.Course.Command.DeleteLesson;
using Application.CQRS.Course.Command.DeleteOption;
using Application.CQRS.Course.Command.DeleteQuestion;
using Application.CQRS.Course.Command.DeleteQuiz;
using Application.CQRS.Course.Command.UpdateCourseModule;
using Application.CQRS.Course.Command.UpdateDisplayPicture;
using Application.CQRS.Course.Command.UpdateLessonFile;
using Application.CQRS.Course.Command.UpdateModuleLesson;
using Application.CQRS.Course.Command.UpdateQuestion;
using Application.CQRS.Course.Query.GetAllCourses;
using Application.CQRS.Course.Query.GetCourse;
using Application.CQRS.Course.Query.GetCourseByCategory;
using Application.CQRS.Course.Query.GetCourseByInstructor;
using Application.CQRS.Course.Query.GetUnverifiedCourses;
using Application.CQRS.Course.Query.GetVerifiedCourses;
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
            var command = new CreateCourseCommand(model);
            var response = await _mediator.Send(command);
            if (response.Status) return Ok(response);
            return BadRequest(model);
        }
        [HttpPut("course/{courseId:guid}")]
        public async Task<IActionResult> UpdateCourse([FromRoute] Guid courseId, UpdateCourseRequestModel model)
        {
            var command = new UpdateCourseCommand(model, courseId);
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

        [HttpPut("module/{courseId:Guid}/{moduleId:Guid}")]
        public async Task<IActionResult> UpdateModule([FromRoute] Guid courseId, [FromRoute] Guid moduleId, [FromBody] string title)
        {
            var command = new UpdateCourseModuleCommand(courseId, moduleId, title);
            await _mediator.Send(command);
            return Ok();
        }
        [HttpPut("lesson/{moduleId:Guid}/{lessonId:Guid}")]
        public async Task<IActionResult> UpdateLesson([FromRoute] Guid moduleId, [FromRoute] Guid lessonId, string? article, string topic, double totalminutes)
        {
            var command = new UpdateModuleLessonCommand(topic, article, moduleId, lessonId, totalminutes);
            var response = await _mediator.Send(command);
            if (response) return Ok();
            return BadRequest();
        }

        [HttpPost("lesson")]
        public async Task<IActionResult> AddLesson([FromForm] AddModuleLessonCommand command)
        {
            var response = await _mediator.Send(command);
            if (response.Status) return Ok(response);
            return BadRequest(response.Message);
        }
        [HttpDelete("module/{courseId:guid}/{moduleId:guid}")]
        public async Task<IActionResult> DeleteModule([FromRoute] Guid courseId, [FromRoute] Guid moduleId)
        {
            var command = new DeleteCourseModuleCommand(courseId, moduleId);
            await _mediator.Send(command);
            return Ok();
        }
        [HttpDelete("lesson/{moduleId:guid}/{lessonId:guid}")]
        public async Task<IActionResult> DeleteLesson([FromRoute] Guid moduleId, [FromRoute] Guid lessonId)
        {
            var command = new DeleteModuleLessonCommand(moduleId, lessonId);
            await _mediator.Send(command);
            return Ok();
        }
        [HttpPost("quiz/{moduleId:guid}")]
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
        [HttpPost("question/{moduleId:guid}/{quizId:guid}")]
        public async Task<IActionResult> AddQuestionToQuiz([FromRoute] Guid moduleId, [FromRoute] Guid quizId, string questionText, QuestionType questionType)
        {
            var command = new AddQuizQuestionCommand(questionText, quizId, questionType, moduleId);
            var response = await _mediator.Send(command);
            if (response.Status) return Ok();
            return BadRequest(response);
        }
        [HttpDelete("question/{moduleId:guid}/{questionId:guid}")]
        public async Task<IActionResult> DeleteQuestion([FromRoute] Guid moduleId, [FromRoute] Guid questionId)
        {
            var command = new DeleteQuizQuestionCommand(moduleId, questionId);
            await _mediator.Send(command);
            return Ok();
        }
        [HttpPost("option{moduleId:guid}/{questionId:guid}")]
        public async Task<IActionResult> AddOptionToQuestion([FromRoute] Guid moduleId, [FromRoute] Guid questionId, string optionText, bool isCorrect)
        {
            var command = new AddQuestionOptionCommand(questionId, isCorrect, optionText, moduleId);
            var response = await _mediator.Send(command);
            if (response.Status) return Ok();
            return BadRequest(response);
        }
        [HttpDelete("option/{moduleId:guid}/{questionId:guid}/{text}")]
        public async Task<IActionResult> RemoveOption([FromRoute] Guid moduleId, [FromRoute] Guid questionId, [FromRoute] string text)
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
        [HttpPut("question/{moduleId:Guid}/{questionId:Guid}")]
        public async Task<IActionResult> UpdateQuestion([FromRoute] Guid moduleId, [FromRoute] Guid questionId, string questionText, QuestionType questionType)
        {
            var command = new UpdateQuestionCommand(questionText, questionType, moduleId, questionId);
            var response = await _mediator.Send(command);
            if (response.Status) return Ok(response);
            return BadRequest();
        }
        [HttpPut("displaypicture")]
        public async Task<IActionResult> UpdateDisplayPicture([FromForm] Guid courseId, IFormFile displayPicture)
        {
            var command = new UpdateDisplayPictureCommand(courseId, displayPicture);
            var response = await _mediator.Send(command);
            if (response.Status) return Ok(response);
            return BadRequest();
        }
        [HttpPut("lessonfile")]
        public async Task<IActionResult> UpdateLessonFile([FromForm] Guid moduleId, IFormFile lessonfile, Guid lessonId)
        {
            var command = new UpdateLessonFileCommand(moduleId, lessonId, lessonfile);
            var response = await _mediator.Send(command);
            if (response) return Ok();
            return BadRequest();
        }
        [HttpGet("getcategorycourses/{categoryId}")]
        public async Task<IActionResult> GetCourseByCategoryId([FromRoute] Guid categoryId)
        {
            var query = new GetCoursesByCategoryQuery(categoryId);
            var response = await _mediator.Send(query);
            if (response.Status) return Ok(response);
            return BadRequest(response.Message);
        }
        [HttpGet("getinstructorcourses/{instructorId}")]
        public async Task<IActionResult> GetCourseByInstructorId([FromRoute] Guid instructorId)
        {
            var query = new GetCoursesByInstructorQuery(instructorId);
            var response = await _mediator.Send(query);
            if (response.Status) return Ok(response);
            return BadRequest(response.Message);
        }
        [HttpGet("verifycourses")]
        public async Task<IActionResult> GetVerifiedCourses()
        {
            var query = new GetVerifiedCoursesQuery();
            var response = await _mediator.Send(query);
            if (response.Status) return Ok(response);
            return BadRequest(response.Message);
        }
        [HttpGet("unverifiedcourses")]
        public async Task<IActionResult> GetUnVerifiedCourses()
        {
            var query = new GetUnverifiedCoursesQuery();
            var response = await _mediator.Send(query);
            if (response.Status) return Ok(response);
            return BadRequest(response.Message);
        }
        [HttpPost("result/{quizId:guid}/{questionId:guid}")]
        public async Task<IActionResult> AddResultToQuiz([FromRoute] Guid quizId, [FromRoute] Guid questionId, List<string> selectedOptions)
        {
            var command = new AddResultCommand(quizId, questionId, selectedOptions);
            var response = await _mediator.Send(command);
            if (response.Status) return Ok(response);
            return BadRequest(response);
        }
    }
}