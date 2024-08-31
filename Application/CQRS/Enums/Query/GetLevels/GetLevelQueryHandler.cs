using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTO;
using Domain.Domain.Shared.Enum;
using MediatR;

namespace Application.CQRS.Enums.Query.GetLevels
{
    public class GetLevelQueryHandler : IRequestHandler<GetLevelQuery, List<EnumDto>>
    {
        public async Task<List<EnumDto>> Handle(GetLevelQuery request, CancellationToken cancellationToken)
        {
            var levels = Enum.GetValues(typeof(Level))
                        .Cast<Level>()
                        .Select(e => new EnumDto
                        {
                            Value = (int)e,
                            Name = e.ToString()
                        })
                        .ToList();
            return levels;
        }
    }
}