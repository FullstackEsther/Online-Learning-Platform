using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTO;
using Domain.RepositoryInterfaces;
using MediatR;

namespace Application.CQRS.Category.Query.GetParentCategories
{
    public class GetParentCategoryQueryHandler : IRequestHandler<GetParentCategoryQuery, BaseResponse<IReadOnlyList<CategoryDto>>>
    {
        private readonly ICategoryRepository _categoryRepository;

        public GetParentCategoryQueryHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public async Task<BaseResponse<IReadOnlyList<CategoryDto>>> Handle(GetParentCategoryQuery request, CancellationToken cancellationToken)
        {
            var parentCategories = await _categoryRepository.GetAllCategories(x => x.ParentCategory == null) ?? throw new ArgumentException("Parent Category doesn't exist");
            return new BaseResponse<IReadOnlyList<CategoryDto>>
            {
                Status = true,
                Message = "Successful",
                Data = parentCategories.Select(x => new CategoryDto
                {
                    Name = x.Name,
                    ParentCategory = x.ParentCategory
                }).ToList()
            };
        }
    }
}