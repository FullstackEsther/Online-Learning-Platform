using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTO;
using MediatR;

namespace Application.CQRS.Course.Command.AddOption
{
    public record AddQuestionOptionCommand(Guid QuestionId, bool IsCorrectoption, string OptionText, Guid ModuleId) : IRequest<BaseResponse<QuestionDto>>;
}