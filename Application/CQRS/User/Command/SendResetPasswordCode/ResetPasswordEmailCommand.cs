using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace Application.CQRS.User.Command.ResetPassword
{
    public record ResetPasswordEmailCommand(string Username): IRequest<bool>;
    
}