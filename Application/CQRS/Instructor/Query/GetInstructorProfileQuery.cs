using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTO;
using MediatR;

namespace Application.CQRS.Instructor.Query
{
    public record GetInstructorProfileQuery() : IRequest<BaseResponse<ProfileDto>>;
}