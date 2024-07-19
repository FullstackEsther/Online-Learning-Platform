using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTO;
using Domain.DomainServices.Interface;
using MediatR;

namespace Application.CQRS.Course.Command.AddResult
{
    public class AddResultCommandHandler : IRequestHandler<AddResultCommand, BaseResponse<ResultDto>>
    {
        private readonly ICurrentUser _currentUser;
        private readonly ICourseManager _courseManager;

        public AddResultCommandHandler(ICurrentUser currentUser, ICourseManager courseManager)
        {
            _currentUser = currentUser;
            _courseManager = courseManager;
        }
        public async Task<BaseResponse<ResultDto>> Handle(AddResultCommand request, CancellationToken cancellationToken)
        {
            var email = _currentUser.GetLoggedInUserEmail();
            var questionAnswers = await _courseManager.AddQuestionAnswerToQuiz(request.QuizId, request.SelectedOption, request.QuestionId);
            var result = await _courseManager.AddResultToQuiz(request.QuizId, questionAnswers, email) ?? throw new ArgumentException("Result not Created");
            return new BaseResponse<ResultDto>
            {
                Status = true,
                Message = "Successful",
                Data = new ResultDto
                {
                    Score = result.Score
                }
            };

        }
    }
}