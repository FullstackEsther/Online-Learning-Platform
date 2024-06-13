using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.DTO
{
    public record RoleDto
    {
        public string RoleName { get; set; }
        public Guid RoleId { get; set; }
    }
    public class RoleRequestModel
    {
        public string RoleName { get; set;}
        public string? Description{ get; set;}
    }
}