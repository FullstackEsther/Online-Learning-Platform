using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTO;
using MediatR;

namespace Application.CQRS.Enums.Query.GetCourseStatus
{
    public record GetCourseStatusQuery() : IRequest<List<EnumDto>>;
}