using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTO;
using MediatR;

namespace Application.CQRS.Course.Command.AddModuleToCourse
{
    public record AddModuleCommand(Guid CourseId, string Title) :IRequest<BaseResponse<ModuleDto>>;
}