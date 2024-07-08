using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.CQRS.Instructor.Query;
using Application.DTO;
using MediatR;

namespace Application.CQRS.Course.Command.AddModuleQuiz
{
    public record AddQuizToModuleCommand(Guid ModuleId, double Duration) : IRequest<BaseResponse<QuizDto>>;
}