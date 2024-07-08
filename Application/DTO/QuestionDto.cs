using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Domain.Shared.Enum;
using Domain.Entities;

namespace Application.DTO
{
    public record QuestionDto
    {
        public string QuestionText {get;set;}
        public Guid QuizId {get;set;}
        public QuestionType QuestionType {get;set;}
        public IReadOnlyList<QuestionOptionDto> questionOptions {get;set;}
    }
}