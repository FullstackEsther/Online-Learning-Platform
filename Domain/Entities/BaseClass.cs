using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public abstract class BaseClass
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string CreatedBy {get;private set;}= default!;
        public DateTime CreatedOn {get;private set;} 
        public string? DeletedBy {get; private set;}
        public DateTime? DeletedOn {get; private set;}

        public void CreateDetails(string userEmail)
        {
            if (userEmail == null)
            {
                throw new ArgumentException("Email cannot be null");
            }
            CreatedBy = userEmail;
            CreatedOn = DateTime.UtcNow;
        }
        public void DeleteDetails(string userEmail)
        {
            if (userEmail == null)
            {
                throw new ArgumentException("Email cannot be null");
            }
            DeletedBy = userEmail;
            DeletedOn = DateTime.UtcNow;
        }

    }
}