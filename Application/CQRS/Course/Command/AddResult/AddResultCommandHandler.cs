using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTO;
using Domain.DomainServices.Interface;
using Domain.ValueObjects;
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
            var email =_currentUser.GetLoggedInUserEmail();
            var questionAnswer = request.QuestionAnswers.Answers.Select(x => new QuestionAnswer
            {
                 QuestionId = x.QuestionId,
                  QuizId = request.QuestionAnswers.QuizId,
                   SelectedOptions = x.SelectedOptions
            }).ToList();
            var result = await _courseManager.AddResultToQuiz(request.QuestionAnswers.QuizId, questionAnswer, email) ?? throw new ArgumentException("Result not Created");
            return new BaseResponse<ResultDto>
            {
                Status = true,
                Message = "Successful",
                Data = new ResultDto
                {
                    Score = result.Score,
                }
            };

        }
    }
}