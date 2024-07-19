using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTO;
using MediatR;

namespace Application.CQRS.Course.Command.AddResult
{
    public record AddResultCommand(Guid QuizId, Guid QuestionId, List<string> SelectedOption) : IRequest<BaseResponse<ResultDto>>;
}