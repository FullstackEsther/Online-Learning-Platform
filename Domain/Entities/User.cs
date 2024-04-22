using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class User : BaseClass
    {
        public required string Username { get; set; }
        private string password;
        public required string Password
        {
            get
            {
                return password;
            }
            set
            {
                if (IsValidPassword(value))
                {
                   password = value; 
                }
                else
                {
                    throw new ArgumentException("Password too weak");
                }
                
            }
        }
        public List<string> RoleName { get; set; } = default!;
        private bool IsValidPassword(string password)
        {
            var pattern = @"^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[^\w\d\s])(?=.*[a-zA-Z\d\W\S]).{8,}$";
            Regex regex = new Regex(pattern);
            return regex.IsMatch(password);
        }
    }
}