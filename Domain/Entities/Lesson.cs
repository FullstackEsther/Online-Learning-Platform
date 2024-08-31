using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Domain.Shared.Enum;
using Domain.Domain.Shared.Exception;

namespace Domain.Entities
{
    public class Lesson : BaseClass
    {
        public  string Topic { get; set; }
        public string File { get; set; }= default!;
        public string? Article { get; set; }= default!;
        public Guid ModuleId { get; private set; } = default!;
        public ICollection<UserProgress> UserProgresses {get;set;} = new HashSet<UserProgress>();
        private double _totalMinutes;
        public double  TotalMinutes { 
            get
            {
                return _totalMinutes;
            }
            set
            {
                 if(value == 0){
                    throw new DomainException("You can not set duration of zero");
                }
                _totalMinutes = value;
            } }
        public Module Module { get; set; }
        internal Lesson(string topic,string file,Guid moduleId,double totalMinutes,string? article)
        {
            Topic = topic;
            File = file;
            ModuleId = moduleId;
            TotalMinutes = totalMinutes;
            Article = article;
        }
        private Lesson()
        {
            
        }
    }
}