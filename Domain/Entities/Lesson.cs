using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Lesson : BaseClass
    {
        public string Topic { get; set; }= default!;
        public string File { get; set; }= default!;
        public TimeSpan TotalTime { get; set; }
        public string ModuleId { get; set; } = default!;
        public Module Module { get; set; }= default!;
    }
}