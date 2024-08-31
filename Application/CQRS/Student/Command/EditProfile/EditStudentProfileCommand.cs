using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTO;
using MediatR;

namespace Application.CQRS.Student.Command.EditProfile
{
    public record EditStudentProfileCommand(UpdateStudentProfileRequestModel Model) :IRequest<BaseResponse<StudentDto>>;
}