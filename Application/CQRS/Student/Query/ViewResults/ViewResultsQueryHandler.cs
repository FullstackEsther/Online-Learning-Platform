using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTO;
using Domain.DomainServices.Interface;
using Domain.RepositoryInterfaces;
using MediatR;

namespace Application.CQRS.Student.Query.ViewResults
{
    public record ViewResultsQueryHandler : IRequestHandler<ViewResultsQuery, BaseResponse<IEnumerable<ResultDto>>>
    {
        private readonly ICurrentUser _currentUser;
        private readonly IStudentRepository _studentRepository;

        public ViewResultsQueryHandler(ICurrentUser currentUser, IStudentRepository studentRepository)
        {
            _currentUser = currentUser;
            _studentRepository = studentRepository;
        }
        public async Task<BaseResponse<IEnumerable<ResultDto>>> Handle(ViewResultsQuery request, CancellationToken cancellationToken)
        {
            var email =  _currentUser.GetLoggedInUserEmail();
            var student = await _studentRepository.Get(x => x.Email == email);
            if (student == null)
            {
                return new BaseResponse<IEnumerable<ResultDto>>
                {
                    Data = null,
                    Message = "No Results yet",
                    Status = false
                };
            }
            return new BaseResponse<IEnumerable<ResultDto>>
            {
                Status = true,
                Message = "Successful",
                Data = student.Results.Select(x => new ResultDto
                {
                    IsPassedTest = x.IsPassedTest,
                    Score = x.Score,
                    QuizDto = x.Quiz == null ? null : new QuizDto
                    {
                        Duration = x.Quiz.Duration,
                        Id = x.Quiz.Id,
                        ModuleId = x.Quiz.ModuleId,
                         ModuleTitle = x.Quiz.Module?.Title,
                        Questions = x.Quiz.Questions.Select(q => new QuestionDto
                        {
                            Id = q.Id,
                            QuestionText = q.QuestionText,
                            QuestionType = q.QuestionType,
                            questionOptions = q.Options.Select(o => new QuestionOptionDto
                            {
                                Option = o.Text
                            }).ToList()?? new List<QuestionOptionDto>()
                        }).ToList() ?? new List<QuestionDto>()
                    }
                }).ToList()
            };
        }
    }
}