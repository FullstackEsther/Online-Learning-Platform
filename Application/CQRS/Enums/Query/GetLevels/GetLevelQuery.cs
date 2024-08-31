using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTO;
using MediatR;

namespace Application.CQRS.Enums.Query.GetLevels
{
    public record GetLevelQuery() : IRequest<List<EnumDto>>;
}