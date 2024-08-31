using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTO;
using Domain.Domain.Shared.Enum;
using MediatR;

namespace Application.CQRS.Course.Command.UpdateQuestion
{
    public record UpdateQuestionCommand(string QuestionText,QuestionType QuestionType, Guid ModuleId, Guid QuestionId) :IRequest<BaseResponse<QuestionDto>>;
}