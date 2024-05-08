using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Lesson : BaseClass
    {
        public required string Topic { get; set; }
        public string File { get; set; }= default!;
        public Guid ModuleId { get; private set; } = default!;
        private double _totalMinutes;
        public double  TotalMinutes { 
            get
            {
                return _totalMinutes;
            }
            set
            {
                 if(value == 0){
                    throw new ArgumentException("You can not set duration of zero");
                }
                _totalMinutes = value;
            } }
        // public Module Module { get; set; }= default!;
        public Lesson(string topic,string file,Guid moduleId,double totalMinutes)
        {
            Topic = topic;
            File = file;
            ModuleId = moduleId;
            TotalMinutes = totalMinutes;
        }
        private Lesson()
        {
            
        }
    }
}