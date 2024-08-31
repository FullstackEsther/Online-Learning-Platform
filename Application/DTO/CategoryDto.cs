using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.DTO
{
    public record CategoryDto
    {
        public Guid Id {get;set;}
        public string Name{get;set;}
        public string Description{get;set;}
        public string? ParentCategory{get;set;}
    }
}