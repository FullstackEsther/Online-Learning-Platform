using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Entities.Chat;
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
        // public override int SaveChanges()
        // {
        //     EntityStateModification();
        //     return base.SaveChanges();
        // }
        // public void EntityStateModification()
        // {
        //     var  anonymousUser = "Anonymous";
        //     foreach (var entry in ChangeTracker.Entries<BaseClass>())
        //     {
        //         switch (entry.State)
        //         {
        //             case EntityState.Added:
        //                 entry.Entity.CreatedOn = DateTime.UtcNow;
        //                 entry.Entity.CreatedBy = _currentUser.GetLoggedInUserEmail() ?? anonymousUser;
        //                 break;
        //             case EntityState.Deleted:
        //                 entry.Entity.DeletedBy =_currentUser.GetLoggedInUserEmail() ?? anonymousUser;
        //                 entry.Entity.DeletedOn = DateTime.UtcNow;
        //                 break;
        //         }
        //     }
        // }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserEntityConfiguration());
            modelBuilder.ApplyConfiguration(new EnrollmentEntityConfiguration());
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
            modelBuilder.ApplyConfiguration(new MessageEntityConfiguration());
            modelBuilder.ApplyConfiguration(new ChatRoomEntityConfiguration());
            modelBuilder.ApplyConfiguration(new PaymentEntityConfiguration());
            modelBuilder.ApplyConfiguration(new UserRolesEntityConfiguration());
            modelBuilder.ApplyConfiguration(new QuestionOptionEntityConfiguration());
            modelBuilder.ApplyConfiguration(new QuizAnswerEntityConfiguration());
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
        public DbSet<Module> Modules { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Payment> Payments { get; set; }
    }
}