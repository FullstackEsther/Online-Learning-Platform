using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTO;
using Domain.RepositoryInterfaces;
using MediatR;

namespace Application.CQRS.Category.Query.GetAllCategory
{
    public class GetAllCategoryQueryHandler : IRequestHandler<GetAllCategoryQuery, BaseResponse<IReadOnlyList<CategoryDto>>>
    {
        private readonly ICategoryRepository _categoryRepository;

        public GetAllCategoryQueryHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public async Task<BaseResponse<IReadOnlyList<CategoryDto>>> Handle(GetAllCategoryQuery request, CancellationToken cancellationToken)
        {
           var categories = await _categoryRepository.GetAllCategories() ?? throw new ArgumentException("There No Categories");
           return new BaseResponse<IReadOnlyList<CategoryDto>>
           {
                 Status = true,
                  Message = "Sucessful",
                   Data = categories.Select(x => new CategoryDto
                   {
                     Id = x.Id,
                     Name = x.Name,
                      ParentCategory = x.ParentCategory
                   }).ToList()
           };
        }
    }
}