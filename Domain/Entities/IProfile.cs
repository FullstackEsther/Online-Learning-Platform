using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public interface IProfile
    {
        string? Biography { get; set; }
        string? ProfilePicture { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
    }
}