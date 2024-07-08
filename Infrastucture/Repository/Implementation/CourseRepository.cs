using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.RepositoryInterfaces;
using Infrastucture.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastucture.Repository.Implementation
{
    public class CourseRepository : BaseRepository<Course>, ICourseRepository
    {
        public CourseRepository(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public void Delete(Course course)
        {
            _applicationContext.Courses.Remove(course);
        }

        public bool Exist(Expression<Func<Course, bool>> predicate)
        {
            return _applicationContext.Courses.Any(predicate);
        }

        public async Task<IEnumerable<Course>> GetAllCourse()
        {
            var courses = await _applicationContext.Courses
            .Include(x => x.Modules).ThenInclude(x => x.Lessons)
            .Include(x => x.Modules)
            .ThenInclude(x => x.Quiz).ThenInclude(x => x.Questions).ThenInclude(x => x.Options)
            .ToListAsync();
            return courses;
        }

        public async Task<IEnumerable<Course>> GetAllCourses(Expression<Func<Course, bool>> predicate)
        {
            return await _applicationContext.Courses
            .Include(x => x.Modules).ThenInclude(x => x.Lessons)
            .Include(x => x.Modules)
            .ThenInclude(x => x.Quiz).ThenInclude(x => x.Questions).ThenInclude(x => x.Options)
            .Where(predicate).ToListAsync();
        }

        public async Task<Course?> GetCourse(Expression<Func<Course, bool>> predicate)
        {
            try
            {
                var course = await _applicationContext.Courses

                .Include(x => x.Modules)
                .ThenInclude(x => x.Lessons)
                .Include(x => x.Modules)
                .ThenInclude(x => x.Quiz).ThenInclude(x => x.Questions)
                .FirstOrDefaultAsync(predicate);
                return course;
            }
            catch (System.Exception ex)
            {

                throw;
            }

        }
        public async Task<IReadOnlyList<Module>> AddModules(IReadOnlyList<Module> modules)
        {
            await _applicationContext.Modules.AddRangeAsync(modules);
            return modules;
        }
    }
}