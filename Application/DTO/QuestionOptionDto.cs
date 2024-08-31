using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.DTO
{
    public class QuestionOptionDto
    {
        public string? Option {get;set;}
        public bool? IsCorrect {get;set;}
    }
     public record OptionRequest
    {
        public string OptionText {get;set;}
        public bool IsCorrect {get;set;}
    }
}