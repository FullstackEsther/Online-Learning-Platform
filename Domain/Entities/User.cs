using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class User:BaseClass
    {
        public required string Email {get; set;}
        public required string Password {get; set;}
        public  string RoleId {get; set;}= default!;
        public  Role Role {get; set;}= default!;
        public  Student Student {get; set;}= default!;
        public  Instructor Instructor {get; set;}= default!;
        
    }
}