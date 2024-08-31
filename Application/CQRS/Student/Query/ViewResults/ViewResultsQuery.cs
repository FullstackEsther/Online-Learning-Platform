using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTO;
using MediatR;

namespace Application.CQRS.Student.Query.ViewResults
{
    public record ViewResultsQuery(): IRequest<BaseResponse<IEnumerable<ResultDto>>>;
}