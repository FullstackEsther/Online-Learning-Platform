using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Role : BaseClass
    {
        public  string  RoleName { get; set; }
        private string? _description;
        public string?  Description { 
            get{
                return _description;
            } 
            set
            {
                if (value?.Length > 50)
                {
                    throw new ArgumentException("Description must be 50 characters or fewer.");
                }
                _description = value;
            } }
        public ICollection<UserRole> UserRoles { get; set; }
        public Role(string roleName)
        {
            RoleName = roleName;
        }
        private Role()
        {
            
        }
    }
}