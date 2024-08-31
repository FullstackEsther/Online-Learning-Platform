using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.DTO
{
    public record EnumDto
    {
        public int Value { get; set; }
        public string Name { get; set; }

    }
}