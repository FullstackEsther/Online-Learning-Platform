using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTO;
using MediatR;

namespace Application.CQRS.User.Query.Get
{
    public record GetUserQuery(Guid? Id, string? UserName ) : IRequest<BaseResponse<UserDto>?>;
    
}