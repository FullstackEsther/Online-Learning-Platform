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
        public string ModuleId { get; set; } = default!;
        public Module Module { get; set; }= default!;
    }
}