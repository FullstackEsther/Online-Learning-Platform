using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Quiz : BaseClass
    {
         public string ModuleId { get; set; }
        public Module Module { get; set; }
        public Result Result { get; set; }
        public IEnumerable<Question> Questions { get; set; }
    }
}