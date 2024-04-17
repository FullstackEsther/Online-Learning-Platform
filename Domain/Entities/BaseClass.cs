using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public abstract class BaseClass
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string CreatedBy {get;set;}= default!;
        public DateTime CreatedOn {get;set;}
        public string? DeletedBy {get;set;}
        public DateTime DeletedOn {get;set;}
    }
}