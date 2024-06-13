using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Services.Interfaces;
using MimeKit;
using MailKit.Net.Smtp;


namespace Application.Services.Implementation
{
    public class MailService : IMailService
    {
        public bool SendCodeToEmail(string recieverEmail, int Code)
        {
            MimeMessage mssg = new MimeMessage ();
            mssg.From.Add(new MailboxAddress("SoftLearn", "ClhProjectEmail@gmail.com"));
            mssg.To.Add(MailboxAddress.Parse(recieverEmail));
            mssg.Subject = "Reset Password Token";
            mssg.Body = new TextPart("html")
            {
                Text = $"<p>Dear {recieverEmail},</p> <p>Your code is:{Code}.Use it to verify your email to reset your password</p><p>If you didn't request this simply ignore this message</p><p>Yours,</p><p>SoftLearn Team</p>"
            };
            string email = "ClhProjectEmail@gmail.com";
            string passWord = "hfsv tewy veqa ciuu";
            SmtpClient client = new SmtpClient();
            try
            {
                client.Connect("smtp.gmail.com" , 465 , true);
                client.Authenticate(email,passWord);
                client.Send(mssg);
                return true;
            }
            finally
            {
                client.Disconnect(true);
                client.Dispose();
            }
        }

        public bool SendEmailWhenMeetingIsScheduled(string recieverEmail, string firstName, DateTime dateTime)
        {
            MimeMessage mssg = new MimeMessage ();
            mssg.From.Add(new MailboxAddress("M-M-A", "ClhProjectEmail@gmail.com"));
            mssg.To.Add(MailboxAddress.Parse(recieverEmail));
            mssg.Subject = "Newly Scheduled Meeting";
            mssg.Body = new TextPart("html")
            {
                Text = $"<p>Dear {firstName},</p><p>I hope this email finds you well.</p><p>This is a reminder that you have a meeting scheduled to chat with your mentor on {dateTime}. Please ensure to log in to the M-M-A app to initiate the chat with your mentor at the scheduled time.</p><p>Thank you for your cooperation.</p><p>Best regards,</p>"
            };
            string email = "ClhProjectEmail@gmail.com";
            string passWord = "hfsv tewy veqa ciuu";
            SmtpClient client = new SmtpClient();
            try
            {
                client.Connect("smtp.gmail.com" , 465 , true);
                client.Authenticate(email,passWord);
                client.Send(mssg);
                return true;
            }
            finally
            {
                client.Disconnect(true);
                client.Dispose();
            }
        }
    }
}