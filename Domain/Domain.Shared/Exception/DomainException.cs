using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Domain.Shared.Exception
{
    public class DomainException : System.Exception
    {
        public int StatusCode { get; }

        public DomainException(string message, int statusCode = 400)
            : base(message)
        {
            StatusCode = statusCode;
        }

        public DomainException(string message, System.Exception innerException, int statusCode = 400)
            : base(message, innerException)
        {
            StatusCode = statusCode;
        }
    }

}