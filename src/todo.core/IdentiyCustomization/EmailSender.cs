using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.UI.Services;

namespace Todo.Core.IdentiyCustomization
{
    public class EmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            // TODO: implement email sending.
            // throw new System.NotImplementedException();
            return Task.CompletedTask;
        }
    }
}