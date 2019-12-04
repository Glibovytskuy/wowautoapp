using WowAutoApp.Services.Email.CreditApplication;

namespace WowAutoApp.Services.Email.Token
{
    public class EmailToken : BaseCreditApplicationEmail
    {
        public string Token { get; set; }
        public string Email { get; set; }
    }
}