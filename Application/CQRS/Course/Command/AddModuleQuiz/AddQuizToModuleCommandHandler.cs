using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTO;
using Domain.DomainServices.Interface;
using MediatR;

namespace Application.CQRS.Course.Command.AddModuleQuiz
{
    public class AddQuizToModuleCommandHandler : IRequestHandler<AddQuizToModuleCommand, BaseResponse<QuizDto>>
    {
        private readonly ICourseManager _courseManager;

        public AddQuizToModuleCommandHandler(ICourseManager courseManager)
        {
            _courseManager = courseManager;
        }
        public async Task<BaseResponse<QuizDto>> Handle(AddQuizToModuleCommand request, CancellationToken cancellationToken)
        {
            var quiz = await _courseManager.AddQuizToModule(request.ModuleId, request.Duration) ?? throw new ArgumentException("Quiz not created");
            return new BaseResponse<QuizDto>
            {
                Status = true,
                Message = "Successful",
                Data = new QuizDto
                {
                     Id = quiz.Id,
                    Duration = quiz.Duration,
                    ModuleId = quiz.ModuleId,
                }
            };
        }
    }
}