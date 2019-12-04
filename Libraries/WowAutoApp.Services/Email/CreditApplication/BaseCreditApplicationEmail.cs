using System;
using System.Collections.Generic;
using System.Text;

namespace WowAutoApp.Services.Email.CreditApplication
{
    public class BaseCreditApplicationEmail
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public string BaseUrl { get; set; }
    }
}