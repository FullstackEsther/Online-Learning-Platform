using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Profile : BaseClass
    {
        private  string _email;
        public  string Email { 
            get
            {
                return _email;
        }
        set
        {

            if (value != null && IsValidEmail(value))
            {
               _email = value; 
            }
            else if (value == null)
            {
                throw new ArgumentException("Email field is required");
            }
            else
            {
                throw new ArgumentException("Invalid EmailFormat");
            }
        } }  
        private string? _biography; 
        public string? Biography { 
            get{
                return _biography;
                }
            set
            {
                if (value != null && value.Length > 250)
                {
                    throw new ArgumentException("Biography must be 250 words or fewer");
                }
                _biography = value; 
            } }
        public string? ProfilePicture { get; set; }
        public string FirstName { get; set; }= default!;
        public string LastName { get; set; }= default!;

        private bool IsValidEmail(string email)
        {
            var pattern = @"^[\w\.-]+@[a-zA-Z\d\.-]+\.[a-zA-Z]{2,}$";
            Regex regex = new(pattern);
            return regex.IsMatch(email);
        }
    }
}