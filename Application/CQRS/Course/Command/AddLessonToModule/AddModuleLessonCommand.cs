using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTO;
using MediatR;

namespace Application.CQRS.Course.Command.AddLessonToModule
{
    public record AddModuleLessonCommand(LessonRequestModel Model) : IRequest<BaseResponse<LessonDto>>;
}