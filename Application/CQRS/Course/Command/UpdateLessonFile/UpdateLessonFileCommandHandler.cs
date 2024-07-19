using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.DomainServices.Interface;
using Domain.RepositoryInterfaces;
using MediatR;

namespace Application.CQRS.Course.Command.UpdateLessonFile
{
    public class UpdateLessonFileCommandHandler : IRequestHandler<UpdateLessonFileCommand,bool>
    {
        private readonly ICourseManager _courseManager;
        private readonly IFileRepository _fileRepository;

        public UpdateLessonFileCommandHandler(ICourseManager courseManager,IFileRepository fileRepository)
        {
            _courseManager = courseManager;
            _fileRepository = fileRepository;
        }
        public async Task<bool> Handle(UpdateLessonFileCommand request, CancellationToken cancellationToken)
        {
            var fileUrl = await _fileRepository.UploadFileAsync(request.File);
           return await _courseManager.UpdateLessonFile(request.ModuleId,fileUrl,request.LessonId)? true : false;
        }
    }
}