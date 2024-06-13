using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public abstract class BaseClass
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string? CreatedBy {get; set;}
        public DateTime? CreatedOn {get;set;} 
        public string? ModifiedBy {get;  set;}
        public DateTime? ModifiedOn {get; set;}

        public void CreateDetails(string userEmail, DateTime dateCreated)
        {
            CreatedBy = userEmail;
            CreatedOn = dateCreated;
        }
        public void DeleteDetails(string userEmail, DateTime dataModified)
        {
            ModifiedBy = userEmail;
            ModifiedOn = dataModified;
        }

    }
}