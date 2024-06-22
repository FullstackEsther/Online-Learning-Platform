using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.DTO
{
    public record UserDto
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public List<string> roleNames {get;set;}
    }
}