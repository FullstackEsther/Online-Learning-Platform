using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.DTO
{
    public record UserProgressDto
    {
        public int NumberOfCompletedLessons{get;set;}
    }
}