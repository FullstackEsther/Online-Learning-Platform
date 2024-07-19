using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.DTO
{
    public record EnrollmentDto
    {
        public Guid StudentId { get; set; } = default!;
        public Guid CourseId { get; set; } = default!;
        public Guid? PaymentId { get; set; } = default!;
    }
}