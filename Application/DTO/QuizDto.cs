using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.DTO
{
    public record QuizDto
    {
        public double Duration { get; set; }
        public Guid ModuleId { get;  set; }
        public IReadOnlyList<QuestionDto> Questions { get; set; }
    }
}