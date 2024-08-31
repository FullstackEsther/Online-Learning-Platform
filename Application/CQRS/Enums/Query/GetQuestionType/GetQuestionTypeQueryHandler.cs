using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTO;
using Domain.Domain.Shared.Enum;
using MediatR;

namespace Application.CQRS.Enums.Query.GetQuestionType
{
    public class GetQuestionTypeQueryHandler : IRequestHandler<GetQuestionTypeQuery, List<EnumDto>>
    {
        public async Task<List<EnumDto>> Handle(GetQuestionTypeQuery request, CancellationToken cancellationToken)
        {
              var questionType = Enum.GetValues(typeof(QuestionType))
                        .Cast<QuestionType>()
                        .Select(e => new EnumDto
                        {
                            Value = (int)e,
                            Name = e.ToString()
                        })
                        .ToList();
            return questionType;
        }
    }
}