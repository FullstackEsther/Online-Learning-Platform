using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTO;
using MediatR;

namespace Application.CQRS.UserProgress.Query.GetUserProgress
{
    public record UserProgressQuery(Guid CourseId) : IRequest<BaseResponse<UserProgressDto>>;
   
}