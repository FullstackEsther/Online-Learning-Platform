using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTO;
using MediatR;

namespace Application.CQRS.Enums.Query.GetQuestionType
{
    public record GetQuestionTypeQuery(): IRequest<List<EnumDto>>;
}