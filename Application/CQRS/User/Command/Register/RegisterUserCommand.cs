using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTO;
using MediatR;

namespace Application.CQRS.User.Command
{
    public record RegisterUserCommand(string UserName, string Password) : IRequest<BaseResponse<UserDto>>;
}