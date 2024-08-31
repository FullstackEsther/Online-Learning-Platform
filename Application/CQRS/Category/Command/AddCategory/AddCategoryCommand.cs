using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTO;
using MediatR;

namespace Application.CQRS.Category.Command.AddCategory
{
    public record AddCategoryCommand(string Name, string Description, string? ParentCategory): IRequest<BaseResponse<CategoryDto>>;
}