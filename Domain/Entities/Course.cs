using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Domain.Shared.Enum;
using Domain.Domain.Shared.Exception;
using Domain.Enum;

namespace Domain.Entities
{
    public class Course : BaseClass
    {
        public string Title { get; set; }
        private string _courseCode;
        public new string CourseCode
        {
            get => _courseCode;
            set
            {
                if (value != null && value.Length < 8)
                {
                    _courseCode = value;
                }
                else
                {
                    throw new DomainException("Course Code must be less than 8 characters");
                }
            }
        }
        private double _price;
        public double? Price
        {
            get => _price;
            set
            {
                if (!value.HasValue) 
                {
                    _price = default; 
                }
                else if (value.Value > 0) 
                {
                    _price = value.Value;
                }
                else
                {
                    throw new DomainException("You cannot add a price of zero or lower than zero");
                }
            }
        }
        private double _totaltime;
        public double TotalTime
        {
            get => _totaltime;
            set
            {
                _totaltime = CalculateTime();
            }
        }
        public string InstructorName { get; set; }
        public string DisplayPicture { get; set; }
        public string WhatToLearn { get; set; } = default!;
        public bool IsVerified { get; private set; }
        public Level Level { get; set; }
        public CourseStatus CourseStatus { get; set; }
        public Guid CategoryId { get; set; } = default!;
        public Guid InstructorId { get; set; } = default!;
        public double TotalScore { get; set; } = default!;
        public ICollection<Module> Modules { get; set; } = new HashSet<Module>();
        public ICollection<UserProgress> UserProgresses { get; set; } = new HashSet<UserProgress>();
        public void AddModule(Module module)
        {
            if (Modules.Any(x => x.Title == module.Title))
            {
                throw new DomainException("Module already exist with this Title");
            }
            module.Course = this;
            Modules.Add(module);
        }
        public void UpdateModule(Module module)
        {
            var existingModule = Modules.FirstOrDefault(m => m.Id == module.Id) ?? throw new DomainException("This module does not exist");
            existingModule = module;
        }
        public void RemoveModule(Module module)
        {
            Modules.Remove(module);
        }
        public void VerifyCourse()
        {
            IsVerified = true;
        }
        public void IsNotVerified()
        {
            IsVerified = false;
        }

        private double CalculateTime()
        {
            double calculatedTime = 0;
            if (Modules != null && Modules.Count != 0)
            {
                foreach (var module in Modules)
                {
                    calculatedTime += module.TotalTime;
                }
            }
            return calculatedTime;
        }
        public int CalculateNumberOfLessons()
        {
            var totalLessons = 0;
            if (Modules.Count != 0 && Modules != null)
            {
                foreach (var module in Modules)
                {
                    if (module.Lessons.Count != 0 && module.Lessons != null)
                    {
                        totalLessons += module.Lessons.Count;
                    }
                }
                return totalLessons;
            }
            return totalLessons;
        }

        public Course(string title, Level level, Guid categoryId, string courseCode, CourseStatus courseStatus, string whatToLearn, string displayPicture)
        {
            Title = title;
            Level = level;
            CategoryId = categoryId;
            CourseCode = courseCode;
            CourseStatus = courseStatus;
            WhatToLearn = whatToLearn;
            DisplayPicture = displayPicture;
        }
        private Course()
        {

        }
        public Instructor Instructor { get; set; }
        public Category Category { get; set; }
        public IEnumerable<Enrollment> Enrollments { get; set; } = new HashSet<Enrollment>();
    }
}