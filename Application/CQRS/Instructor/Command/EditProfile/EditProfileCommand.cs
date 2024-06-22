using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTO;
using MediatR;

namespace Application.CQRS.Instructor.Command.EditProfile
{
    public record EditProfileCommand(UpdateInstructorRequestModel Model): IRequest<BaseResponse<InstructorDto>>; 
}