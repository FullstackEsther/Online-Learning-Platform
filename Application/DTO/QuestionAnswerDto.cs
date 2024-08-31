using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.DTO
{
    public record QuestionAnswerDto
    {
        
    }
    public record QuestionAnswerRequestModel
    {
        public required Guid QuizId {get; set;}
        public required ICollection<Answers> Answers {get; set;}
    }

    public record Answers
    {
        public required Guid QuestionId {get;set;}
        public required List<string> SelectedOptions{get;set;}
    }
}