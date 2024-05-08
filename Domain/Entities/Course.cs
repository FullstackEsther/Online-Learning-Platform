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
        public required string Title { get; set; }
        private string _id;
        public new required string Id { 
            get => _id;
            set
            {
               var code =  Title[..3].ToUpper();
               var num = new Random().Next(100, 199);
               var courseCode = $"{code}{num}";
               _id = courseCode;
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
        public double TotalTime {get;set;}
        public int numberOfModules {get;set;}
        public required string InstructorName { get; set; }
        public required string DisplayPicture { get; set; }
        public  string WhatToLearn { get; set; } = default!;
        public bool IsVerified {get; private set;} 
        public Level Level { get; set; }
        public CourseStatus CourseStatus { get; set; }
        public Guid CategoryId { get; set; } = default!;
        public Guid InstructorId { get; set; } = default!;
        public double TotalScore { get; set; } = default!;

        public void VerifyCourse()
        {
            IsVerified = true;
        }
        public void IsNotVerified()
        {
            IsVerified = false;
        }
        // public ICollection<Module> Modules { get; set; } = new HashSet<Module>();
        // public virtual Instructor Instructor { get; set; } = default!;
        // public virtual Category Category { get; set; } = default!;
        // public IEnumerable<Enrollment> Enrollments { get; set; } = new HashSet<Enrollment>();

        // private string CalculateTime()
        // {
        //     double hours=0,minutes=0,seconds=0;
        //     foreach (var module in Modules)
        //     {
        //         var  time = module.TotalTime.Split(':');
        //         hours =+ Double.Parse(time[0]);
        //         minutes =+ Double.Parse(time[1]);
        //         seconds =+ Double.Parse(time[2]);
        //     }
        //     var convertedTime = $"{hours}:{minutes}:{seconds}";
        //     return convertedTime;
        // }
    }
}