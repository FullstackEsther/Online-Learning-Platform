using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Services.Interfaces
{
    public interface IMailService
    {
        public bool SendCodeToEmail (string recieverEmail, int Code);
        public bool SendEmailWhenMeetingIsScheduled (string recieverEmail, string firstName, DateTime dateTime);
    }
}