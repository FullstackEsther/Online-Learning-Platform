using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTO;
using Domain.DomainServices.Interface;
using Domain.RepositoryInterfaces;
using MediatR;

namespace Application.CQRS.Course.Command.UpdateModuleLesson
{
    public class UpdateModuleLessonCommandHandler : IRequestHandler<UpdateModuleLessonCommand, bool>
    {
        private readonly ICourseManager _courseManager;
        private readonly IFileRepository _fileRepository;

        public UpdateModuleLessonCommandHandler(ICourseManager courseManager, IFileRepository fileRepository)
        {
            _courseManager = courseManager;
            _fileRepository = fileRepository;
        }
        public async Task<bool> Handle(UpdateModuleLessonCommand request, CancellationToken cancellationToken)
        {
          return await _courseManager.UpdateModuleLesson(request.Topic,request.ModuleId,request.TotalMinutes,request.Article,request.LessonId);
        }
    }
}