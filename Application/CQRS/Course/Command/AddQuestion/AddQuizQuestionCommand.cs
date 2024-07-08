using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTO;
using Domain.Domain.Shared.Enum;
using MediatR;

namespace Application.CQRS.Course.Command.AddQuestion
{
    public record AddQuizQuestionCommand(string QuestionText, Guid QuizId, QuestionType QuestionType, Guid ModuleId) : IRequest<BaseResponse<QuestionDto>>;
}