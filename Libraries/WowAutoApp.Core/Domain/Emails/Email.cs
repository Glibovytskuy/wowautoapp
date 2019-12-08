using System.Collections.Generic;

namespace WowAutoApp.Core.Domain.Emails
{
    /// <summary>
    /// Our custom Email type to provide single entry point for different email sending service implementations
    /// </summary>
    public class Email
    {
        public Email()
        {
            Attachments = new List<byte[]>();
        }

        public string Body { get; set; }
        public string Subject { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public List<byte[]> Attachments { get; set; }
    }
}