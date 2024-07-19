using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTO;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.CQRS.Course.Command.UpdateDisplayPicture
{
    public record UpdateDisplayPictureCommand(Guid CourseId, IFormFile File):IRequest<BaseResponse<CourseDto>>;
}