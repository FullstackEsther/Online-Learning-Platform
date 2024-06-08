using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Domain.Shared.Enum;
using Domain.Enum;

namespace Domain.Entities
{
    public class Course : BaseClass
    {
        public  string Title { get; set; }
        private string _courseCode;
        public new  string CourseCode { 
            get => _courseCode;
            set
            {
                if (value != null && value.Length <8)
                {
                    _courseCode = value;
                }
                else
                {
                    throw new ArgumentException("Course Code must be less than 8 characters");
                }
            }
        } 
        private double _price;
        public double? Price { 
            get => _price;
             set
             {
                if (value.HasValue && value >= 0)
                {
                    _price = (double)value;
                }
                else
                {
                    throw new ArgumentException("You cannot add a price of zero or lower than zero");
                }
             }}
        private double _totaltime;   
        public double TotalTime {
            get => _totaltime;
            set
            {
                _totaltime = CalculateTime();
            }
        }
        public  string InstructorName { get; set; }
        public  string DisplayPicture { get; set; }
        public  string WhatToLearn { get; set; } = default!;
        public bool IsVerified {get; private set;} 
        public Level Level { get; set; }
        public CourseStatus CourseStatus { get; set; }
        public Guid CategoryId { get; set; } = default!;
        public Guid InstructorId { get; set; } = default!;
        public double TotalScore { get; set; } = default!;
        public  ICollection<Module> Modules { get; set; } = new HashSet<Module>();
        public void CreateModule(Module module)
        {
            if (module == null)
            {
                throw new ArgumentException("Module cannot be null");
            }
            
            Modules.Add(module);
        }
        // public void UpdateModule(Module module)
        // {
        //     if (module == null) { throw new ArgumentNullException("An empty module cannot be updated"); }
        //     var existingModule = Modules.FirstOrDefault(m => m.Id == module.Id);
        //     if (existingModule == null)
        //     {
        //         throw new ArgumentException("This module does not exist");
        //     }
        //     existingModule = module;
        // }
        public void RemoveModule(Module module)
        {
            if (module == null)
            {
                throw new ArgumentException("Module cannot be null");
            }
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
            double calculatedTime =0;
            foreach (var module in Modules)
            {
                calculatedTime = module.TotalTime;
            }
            return calculatedTime;
        }
        
        public Course(string title, string courseCode,string displayPicture, string whatToLearn,Level level, CourseStatus courseStatus)
        {
            Title = title;
            CourseCode = courseCode;
            DisplayPicture = displayPicture;
            WhatToLearn = whatToLearn;
            Level = level;
            CourseStatus = courseStatus;
        }
        private Course()
        {

        }

        // public virtual Instructor Instructor { get; set; } = default!;
        // public virtual Category Category { get; set; } = default!;
        // public virtual IEnumerable<Enrollment> Enrollments { get; set; } = new HashSet<Enrollment>();
    }
}