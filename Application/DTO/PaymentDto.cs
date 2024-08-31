using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.DTO
{
    public record PaymentDto
    {
        public decimal Amount { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string TrxRef { get; set; }
        public string AuthorizationUrl { get; set; }
    }
}