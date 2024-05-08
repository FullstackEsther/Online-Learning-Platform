using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.DomainServices.Interfaces
{
    public interface IResultManager
    {
        public string SerializeDictionary(Dictionary<Question,string> answers);
        public Dictionary<Question,string> DeserializeDictionary(Result result);
    }
}