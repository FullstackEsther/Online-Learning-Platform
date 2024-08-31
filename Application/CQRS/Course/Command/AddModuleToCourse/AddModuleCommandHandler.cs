using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTO;
using Domain.DomainServices.Interface;
using MediatR;

namespace Application.CQRS.Course.Command.AddModuleToCourse
{
    public class AddModuleCommandHandler : IRequestHandler<AddModuleCommand, BaseResponse<ModuleDto>>
    {
        private readonly ICourseManager _courseManager;

        public AddModuleCommandHandler(ICourseManager courseManager)
        {
            _courseManager = courseManager;
        }

        public async Task<BaseResponse<ModuleDto>> Handle(AddModuleCommand request, CancellationToken cancellationToken)
        {
            var module = await _courseManager.AddModuleToCourse(request.CourseId, request.Title);
            if (module != null)
            {
                return new BaseResponse<ModuleDto>
                {
                    Status = true,
                    Message = "Successful",
                    Data = new ModuleDto
                    {
                        CourseId = module.CourseId,
                        Id = module.Id,
                        Title = module.Title,
                    }
                };
            }
            return new BaseResponse<ModuleDto>
            {
                Data = null,
                Message = "Not Created",
                Status = false
            };
        }
    }
}