using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTO;
using Domain.DomainServices.Interface;
using MediatR;

namespace Application.CQRS.Course.Command.AddQuestion
{
    public class AddQuizQuestionCommandHandler : IRequestHandler<AddQuizQuestionCommand, BaseResponse<QuestionDto>>
    {
        private readonly ICourseManager _courseManager;

        public AddQuizQuestionCommandHandler(ICourseManager courseManager)
        {
            _courseManager = courseManager;
        }
        public async Task<BaseResponse<QuestionDto>> Handle(AddQuizQuestionCommand request, CancellationToken cancellationToken)
        {
            var question = await _courseManager.AddQuestionToQuiz(request.QuizId, request.ModuleId, request.QuestionType, request.QuestionText) ?? throw new System.Exception("Question not created");
            return new BaseResponse<QuestionDto>
            {
                Status = true,
                Message = "Successful",
                Data = new QuestionDto
                {
                    QuestionText = question.QuestionText,
                    QuizId = question.QuizId,
                    QuestionType = question.QuestionType
                }
            };
        }
    }
}