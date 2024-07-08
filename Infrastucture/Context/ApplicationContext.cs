using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Entities.Chat;
using Domain.ValueObjects;
using Infrastucture.Context.EntityConfiguration;
using Microsoft.EntityFrameworkCore;


namespace Infrastucture.Context
{
    public class ApplicationContext : DbContext
    {


        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySQL("AppString",
                    sqlOptions => sqlOptions.MigrationsAssembly("Infrastucture"));
            }
        }
        // public  override Task<int> SaveChangesAsync(CancellationToken token = default)
        // {
        //     EntityStateModification();
        //     return  base.SaveChangesAsync();
        // }
        // public void EntityStateModification()
        // {
        //     // var  anonymousUser = "Anonymous";
        //     foreach (var entry in ChangeTracker.Entries<BaseClass>())
        //     {
                // switch (entry.State)
                // {
                //     case EntityState.Added:
                //         entry.Entity.CreatedOn = DateTime.UtcNow;
                //         // entry.Entity.CreatedBy = _currentUser.GetLoggedInUserEmail() ?? anonymousUser;
                //         break;
                //     case EntityState.Deleted:
                //         // entry.Entity.DeletedBy =_currentUser.GetLoggedInUserEmail() ?? anonymousUser;
                //         // entry.Entity.DeletedOn = DateTime.UtcNow;
                //         break;
                // }
        //     }
        // }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<QuestionAnswer>();
            modelBuilder.Ignore<QuestionOption>();
          modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ChatRoom> ChatRooms { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Result> Results { get; set; }
        public DbSet<Quiz> Quizzes { get; set; }
        // public DbSet<QuizAnswer> Answers { get; set; }
        public DbSet<Question> Questions { get; set; }
        // public DbSet<QuestionOption> Options { get; set; }
        public DbSet<Domain.Entities.Module> Modules { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Payment> Payments { get; set; }
    }
}