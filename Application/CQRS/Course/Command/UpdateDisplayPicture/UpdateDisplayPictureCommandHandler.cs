using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTO;
using Domain.DomainServices.Interface;
using Domain.RepositoryInterfaces;
using MediatR;

namespace Application.CQRS.Course.Command.UpdateDisplayPicture
{
    public class UpdateDisplayPictureCommandHandler : IRequestHandler<UpdateDisplayPictureCommand, BaseResponse<CourseDto>>
    {
        private readonly ICourseManager _courseManager;
        private readonly IFileRepository _fileRepository;

        public UpdateDisplayPictureCommandHandler(ICourseManager courseManager, IFileRepository fileRepository)
        {
            _courseManager = courseManager;
            _fileRepository = fileRepository;
        }
        public async Task<BaseResponse<CourseDto>> Handle(UpdateDisplayPictureCommand request, CancellationToken cancellationToken)
        {
            var url = await _fileRepository.UploadFileAsync(request.File) ?? throw new ArgumentException("Upload not successful");
            var updatedCourse = await _courseManager.UpdateDisplaypicture(request.CourseId, url) ?? throw new ArgumentException("Display picture not Updated");
            return new BaseResponse<CourseDto>
            {
                Status = true,
                Message = "Successful",
                Data = new CourseDto
                {
                    DisplayPicture = updatedCourse.DisplayPicture,
                    CourseCode = updatedCourse.CourseCode,
                    InstructorName = updatedCourse.InstructorName,
                    Title = updatedCourse.Title,
                    Level = updatedCourse.Level,

                }
            };
        }
    }
}