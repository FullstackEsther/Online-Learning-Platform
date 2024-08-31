using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTO;
using MediatR;

namespace Application.CQRS.User.Command.AssignRole
{
    public record AssignRoleCommand(string RoleName) : IRequest<BaseResponse<UserDto>>;
}