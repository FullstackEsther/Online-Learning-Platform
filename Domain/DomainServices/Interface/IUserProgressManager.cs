using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.DomainServices.Interface
{
    public interface IUserProgressManager
    {
        Task<UserProgress> CreateUserProgress( string email, Guid lessonId, Guid courseId);
        Task<UserProgress> UpdateUserProgress(string email, Guid lessonId, Guid courseId);
        public  Task<int> CalculateUserProgress(string email, Guid courseId);
    }
}