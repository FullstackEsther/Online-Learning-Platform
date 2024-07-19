using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.RepositoryInterfaces;
using MediatR;

namespace Application.CQRS.Category.Command.DeleteCategory
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand>
    {
        private readonly ICategoryRepository _categoryRepository;

        public DeleteCategoryCommandHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public async Task Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
           var category = await  _categoryRepository.Get(x => x.Id == request.CategoryId) ?? throw new System.Exception("Category doesn't exist");
           _categoryRepository.Delete(category);
           await _categoryRepository.Save();
        }
    }
}