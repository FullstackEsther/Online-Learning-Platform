using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace Application.CQRS.User.Command
{
    public record ResetPasswordCommand(string UserName , string Password, string ConfirmPassword):IRequest<bool>;
}