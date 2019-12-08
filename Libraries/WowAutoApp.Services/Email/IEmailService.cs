using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WowAutoApp.Services.Email
{
    public interface IEmailService
    {
        void Send(Core.Domain.Emails.Email email);
        void Send(string body, string subject, string from, string to);
        Task SendAsync(Core.Domain.Emails.Email email);
        Task SendAsync(string body, string subject, string from, string to);
    }
}