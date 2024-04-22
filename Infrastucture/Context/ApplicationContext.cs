using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Infrastucture.Context.EntityConfiguration;
using Microsoft.EntityFrameworkCore;

namespace Infrastucture.Context
{
    public class ApplicationContext : DbContext 
    {
        public ApplicationContext(DbContextOptions options): base(options)
        {
            
        } 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserEntityConfiguration());
            modelBuilder.ApplyConfiguration(new StudentCourseEntityConfiguration());
            modelBuilder.ApplyConfiguration(new StudentEntityConfiguration());
            modelBuilder.ApplyConfiguration(new RoleEntityConfiguration());
            modelBuilder.ApplyConfiguration(new ResultEntityConfiguration());
            modelBuilder.ApplyConfiguration(new QuizEntityConfiguration());
            modelBuilder.ApplyConfiguration(new QuestionEntityConfiguration());
            modelBuilder.ApplyConfiguration(new ModuleEntityConfiguration());
            modelBuilder.ApplyConfiguration(new LessonEntityConfiguration());
            modelBuilder.ApplyConfiguration(new InstructorEntityConfiguration());
            modelBuilder.ApplyConfiguration(new CoursesEntityConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryEntityConfiguration());
        }
         public DbSet<User> Users {get; set;}
        public DbSet<Role> Roles {get; set;}
        public DbSet<Category> Categories {get; set;}
        public DbSet<Enrollment> StudentCourses {get; set;}
        public DbSet<Student> Students {get; set;}
        public DbSet<Result> Results {get; set;}
        public DbSet<Quiz> Quizzes {get; set;}
        public DbSet<Question> Questions {get; set;}
        public DbSet<Module> Modules {get; set;}
        public DbSet<Lesson> Lessons {get; set;}
        public DbSet<Instructor> Instructors {get; set;}
        public DbSet<Course> Courses {get; set;}
    }
}