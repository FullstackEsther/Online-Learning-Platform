using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.DTO
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public List<string> roleNames {get;set;}
    }
    public class RegisterRequestModel
    {
        public string UserName { get; set;}
        public string Password { get; set; }
    }

    public class LoginRequestModel
    {
        public string UserName {get;set;}
        public string Password { get; set; }
    }
}