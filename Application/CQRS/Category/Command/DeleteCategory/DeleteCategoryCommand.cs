using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace Application.CQRS.Category.Command.DeleteCategory
{
    public record DeleteCategoryCommand(Guid CategoryId): IRequest;
}