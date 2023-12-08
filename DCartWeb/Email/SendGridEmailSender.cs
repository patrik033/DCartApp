using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace DCartWeb.Email
{
    /// <summary>
    /// Send an Email with the SendGrid provider https://sendgrid.com/
    /// </summary>
    public class SendGridEmailSender : ISendGridEmailSender
    {
        private readonly IOptions<EmailSettings> _emailSettings;

        //To retrieve the options from the configuration
        public SendGridEmailSender(IOptions<EmailSettings> emailSettings)
        {
            _emailSettings = emailSettings;
        }

        //Send an email
        public async Task SendAsync(string from, string to, string subject, string body, string confirmationLink)
        {

            /*Can use the api key either stored as en environment variable or 
            it can be stored in the configuration/appsetting
            don't expose the project as public if you want to store the key in the appsettings!
            the key will become blocked by sendgrid and you will have to generate a new one
             */

            var apiKey = Environment.GetEnvironmentVariable("SENDGRID_API_KEY");

            //var apiKey = _emailSettings.Value.Key;
            var client = new SendGridClient(apiKey);
            var msg = new SendGridMessage()
            {
                From = new EmailAddress(from, "WebApp Registration"),
                Subject = subject,
                //PlainTextContent = body,
                HtmlContent = $"<strong>{body}</strong>"
            };
            msg.AddTo(new EmailAddress(to));
            var response = await client.SendEmailAsync(msg).ConfigureAwait(false);
        }
    }
}
