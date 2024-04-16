using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Role : BaseClass
    {
        public string  RoleName { get; set; }
        public string  Description { get; set; }
        public IEnumerable<User> Users { get; set;}= new HashSet<User>();
    }
}