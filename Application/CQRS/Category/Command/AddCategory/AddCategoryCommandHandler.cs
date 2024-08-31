using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTO;
using Domain.DomainServices.Interface;
using Domain.RepositoryInterfaces;
using MediatR;

namespace Application.CQRS.Category.Command.AddCategory
{
    public class AddCategoryCommandHandler : IRequestHandler<AddCategoryCommand, BaseResponse<CategoryDto>>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly ICurrentUser _currentUser;

        public AddCategoryCommandHandler(ICategoryRepository categoryRepository, ICurrentUser currentUser)
        {
            _categoryRepository = categoryRepository;
            _currentUser = currentUser;
        }
        public async Task<BaseResponse<CategoryDto>> Handle(AddCategoryCommand request, CancellationToken cancellationToken)
        {
            var existing = _categoryRepository.Exist(x => x.Name == request.Name);
            if (existing) throw new ArgumentException("Category already exist");
            var category = new Domain.Entities.Category(request.Name, request.Description)
            {
                ParentCategory = request.ParentCategory
            };
            category.CreateDetails(_currentUser.GetLoggedInUserEmail(), DateTime.UtcNow);
            await _categoryRepository.Create(category);
            if (await _categoryRepository.Save() > 0)
            {
                return new BaseResponse<CategoryDto>
                {
                    Status = true,
                    Message = "Successful",
                    Data = new CategoryDto
                    {
                        Name = request.Name,
                        ParentCategory = request.ParentCategory
                    }
                };
            }
            return new BaseResponse<CategoryDto>
            {
                Data = null,
                Message = " Not Created",
                Status = false
            };
        }
    }
}