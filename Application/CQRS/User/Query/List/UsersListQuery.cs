using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTO;
using MediatR;

namespace Application.CQRS.User.Query
{
    public record UsersListQuery : IRequest<BaseResponse<List<UserDto>>>;
}