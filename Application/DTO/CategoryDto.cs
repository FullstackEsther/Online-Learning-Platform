using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.DTO
{
    public record CategoryDto
    {
        public string Name{get;set;}
        public string? ParentCategory{get;set;}
    }
}