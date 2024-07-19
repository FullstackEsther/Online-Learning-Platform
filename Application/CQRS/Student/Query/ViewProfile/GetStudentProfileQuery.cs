using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTO;
using MediatR;

namespace Application.CQRS.Student.Query.ViewProfile
{
    public record GetStudentProfileQuery() : IRequest<BaseResponse<StudentDto>>;
}