using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTO;
using Domain.DomainServices.Interface;
using MediatR;

namespace Application.CQRS.Course.Command.UpdateQuestion
{
    public class UpdateQuestionCommandHandler : IRequestHandler<UpdateQuestionCommand, BaseResponse<QuestionDto>>
    {
        private readonly ICourseManager _courseManager;

        public UpdateQuestionCommandHandler(ICourseManager courseManager)
        {
            _courseManager = courseManager;
        }
        public async Task<BaseResponse<QuestionDto>> Handle(UpdateQuestionCommand request, CancellationToken cancellationToken)
        {
            var response = await _courseManager.UpdateQuizQuestion(request.QuestionText, request.ModuleId, request.QuestionType, request.QuestionId);
            if (response)
            {
                return new BaseResponse<QuestionDto>
                {
                    Status = true,
                    Message = "Successfully Updated",
                    Data = new QuestionDto
                    {
                        QuestionText = request.QuestionText,
                        QuestionType = request.QuestionType,

                    }
                };
            }
            return null;
        }
    }
}