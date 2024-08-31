using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTO;
using Domain.Enum;
using MediatR;

namespace Application.CQRS.Enums.Query.GetCourseStatus
{
    public class GetCourseStatusQueryHandler : IRequestHandler<GetCourseStatusQuery, List<EnumDto>>
    {
        public async Task<List<EnumDto>> Handle(GetCourseStatusQuery request, CancellationToken cancellationToken)
        {
            var statuses = Enum.GetValues(typeof(CourseStatus))
                          .Cast<CourseStatus>()
                          .Select(e => new EnumDto
                          {
                              Value = (int)e,
                              Name = e.ToString()
                          })
                          .ToList();
            return statuses;
        }
    }
}