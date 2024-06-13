using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace Application.CQRS.User.Command.UpdatePassword
{
    public record UpdatePasswordCommand(string OldPassword, string NewPassword) : IRequest<bool>;
}