using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTO;
using MediatR;

namespace Application.CQRS.Student.Command.CreateProfile
{
    public record CreateProfileCommand(CreateStudentProfileRequestModel Model): IRequest<BaseResponse<StudentDto>>;
}