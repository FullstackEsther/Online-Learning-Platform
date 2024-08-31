using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTO;
using MediatR;

namespace Application.CQRS.Enrollment.Query.GetEnrollments
{
    public record GetEnrollmentQuery() : IRequest<BaseResponse<IEnumerable<EnrollmentDto>>>;
}