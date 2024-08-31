using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTO;
using MediatR;

namespace Application.CQRS.Category.Query.GetParentCategories
{
    public record GetParentCategoryQuery() : IRequest<BaseResponse<IReadOnlyList<CategoryDto>>>;
}