using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTO;
using Domain.DomainServices.Interface;
using MediatR;

namespace Application.CQRS.Course.Command.AddOption
{
    public class AddQuestionOptionCommandHandler : IRequestHandler<AddQuestionOptionCommand, BaseResponse<QuestionDto>>
    {
        private readonly ICourseManager _courseManager;

        public AddQuestionOptionCommandHandler(ICourseManager courseManager)
        {
            _courseManager = courseManager;
        }
        public async Task<BaseResponse<QuestionDto>> Handle(AddQuestionOptionCommand request, CancellationToken cancellationToken)
        {
            var question = await _courseManager.AddOptionToQuestion(request.QuestionId, request.IsCorrectoption, request.OptionText, request.ModuleId);
            if (question == null)
            {
                return new BaseResponse<QuestionDto>
                {
                    Data = null,
                    Message = "Option not created",
                    Status = false
                };
            }
            return new BaseResponse<QuestionDto>
            {
                Status = true,
                Message = "Successful",
                Data = new QuestionDto
                {
                    QuestionText = question.QuestionText,
                    QuestionType = question.QuestionType,
                    QuizId = question.QuizId,
                }
            };
        }
    }
}