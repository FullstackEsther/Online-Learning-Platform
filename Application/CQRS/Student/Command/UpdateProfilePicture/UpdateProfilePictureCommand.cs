using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTO;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.CQRS.Student.Command.UpdateProfilePicture
{
    public record UpdateProfilePictureCommand(IFormFile File) : IRequest<BaseResponse<StudentDto>>;
}