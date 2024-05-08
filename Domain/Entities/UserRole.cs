using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class UserRole :BaseClass
    {
        public Guid UserId { get; set; } = default!;
        public Guid RoleId { get; set; }= default!;
        // public User User { get; set; }= default!;
        // public Role Role { get; set; }= default!;
    }
}