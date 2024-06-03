using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Payment : BaseClass
    {
        public decimal Amount { get; set; }=default!;
        public string Email { get; set; }=default!;
        public string  TrxRef { get; set; } 
        public bool  Status { get; set; } 
        public Enrollment Enrollment { get; set; } = default!;

    }
}