using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTO;
using MediatR;

namespace Application.CQRS.Enrollment.Command.Enroll
{
    public record StudentEnrollmentCommand(Guid CourseId, string Reference): IRequest<BaseResponse<EnrollmentDto>>;
}