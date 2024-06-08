using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class User : BaseClass
    {
        public  string Username { get; set; }
        private string _password;
        public ICollection<UserRole> UserRoles { get; set; }
        public  string Password
        {
             get
            {
                return _password;
            }
            set
            {
                if (IsValidPassword(value))
                {
                    _password = value;
                }
                else
                {
                    throw new ArgumentException("Password too weak");
                }

            }
        }
        private bool IsValidPassword(string password)
        {
            var pattern = @"^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[^\w\d\s])(?=.*[a-zA-Z\d\W\S]).{8,}$";
            Regex regex = new Regex(pattern);
            return regex.IsMatch(password);
        }
        public void ChangePassword(string password)
        {
            if (IsValidPassword(password))
            {
                _password = password;
                
            }
            else
            {
                throw new ArgumentException("Password too weak");
            }
        } 
        public void ForgotPassword(string password, string confirmPassword)
        {
            if (IsValidPassword(password) && IsValidPassword(confirmPassword) )
            {
                if (password == confirmPassword)
                {
                    _password = password;
                }
                else
                {
                    throw new ArgumentException("Password doesnot match");
                }
            }
            else
            {
                throw new ArgumentException("Password too weak");
            }
        }
        public void AddRole(string role)
        {
            if (!UserRoles.Any(x => x.Role.RoleName == role))
            {
                UserRoles.Add(new UserRole{ Role = new Role(role)});
            }
            else
            {
                throw new ArgumentException("User already has the role");
            }
        }
        public User(string userName, string password)
        {
            Username = userName;
            Password = password;
            UserRoles = new HashSet<UserRole>();
        }
        private User()
        {
            
        }
    }
}