using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class User : BaseClass
    {
        private static readonly Random rand = new Random();
        private string _username;
        public string Username
        {
            get => _username;
            set
            {
                if (IsvalidEmail(value))
                {
                    _username = value;
                }
                else
                {
                    throw new ArgumentException("Email format is incorrect");
                }
            }
        }
        private string _password;
        private int _resetPasswordCode;
        public int ResetPasswordCode
        {
            get => _resetPasswordCode;
            set
            {
                GenerateCode();
            }
        }
        public ICollection<UserRole> UserRoles { get; set; }
        public ICollection<UserProgress> UserProgresses {get;set;} = new HashSet<UserProgress>();
        public string Password
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
        private bool IsvalidEmail(string email)
        {
            var pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            Regex regex = new Regex(pattern);
            return regex.IsMatch(email);
        }
        public void ChangePassword(string newPassword, string oldPassword)
        {
            if (IsValidPassword(oldPassword) && IsValidPassword(newPassword))
            {
                if (_password == oldPassword)
                {
                    _password = newPassword;
                }
                else
                {
                    throw new ArgumentException("Old Password doesn't match");
                }

            }
            else
            {
                throw new ArgumentException("Password too weak");
            }
        }
        public void ForgotPassword(string password, string confirmPassword)
        {
            if (IsValidPassword(password))
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
        public UserRole AddRole(User user, Role role)
        {
            if (!UserRoles.Any(x => x.Role.RoleName == role.RoleName))
            {
                var userRole = new UserRole
                {
                    Role = role,
                    RoleId = role.Id,
                    User = user,
                    UserId = user.Id
                };
                UserRoles.Add(userRole);
                return userRole;
            }
            else
            {
                throw new ArgumentException("User already has the role");
            }
        }
        public int GenerateCode()
        {
            _resetPasswordCode = rand.Next(23456, 3455667);
            return _resetPasswordCode;
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