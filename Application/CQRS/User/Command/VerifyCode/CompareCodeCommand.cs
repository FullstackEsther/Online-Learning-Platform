using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace Application.CQRS.User.Command.CompareSentCode
{
    public record CompareCodeCommand(string Email, int Code): IRequest<bool>;
}