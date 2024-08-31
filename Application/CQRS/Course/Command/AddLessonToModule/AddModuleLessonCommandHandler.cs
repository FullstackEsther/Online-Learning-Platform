using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTO;
using Domain.DomainServices.Interface;
using Domain.RepositoryInterfaces;
using MediatR;

namespace Application.CQRS.Course.Command.AddLessonToModule
{
    public class AddModuleLessonCommandHandler : IRequestHandler<AddModuleLessonCommand, BaseResponse<LessonDto>>
    {
        private readonly ICourseManager _courseManager;
        private readonly IFileRepository _fileRepository;

        public AddModuleLessonCommandHandler(ICourseManager courseManager, IFileRepository fileRepository)
        {
            _courseManager = courseManager;
            _fileRepository = fileRepository;
        }
        public async Task<BaseResponse<LessonDto>> Handle(AddModuleLessonCommand request, CancellationToken cancellationToken)
        {
            var file = string.Empty;
            if (request.Model.File != null)
            {
                file = await _fileRepository.UploadFileAsync(request.Model.File);
            }
            var createLesson = await _courseManager.AddLessonToModule(request.Model.ModuleId, request.Model.Topic, file, request.Model.TotalMinutes, request.Model.Article);
            if (createLesson != null)
            {
                return new BaseResponse<LessonDto>
                {
                    Status = true,
                    Message = "Successful",
                    Data = new LessonDto
                    {
                          Id = createLesson.Id,
                        Article = createLesson.Article,
                        File = createLesson.File,
                        ModuleId = createLesson.ModuleId,
                        Topic = createLesson.Topic,
                        TotalMinutes = createLesson.TotalMinutes
                    }
                };
            }
            return null;

        }
    }
}