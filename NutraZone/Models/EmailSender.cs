using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Configuration;
using System;
using SendGrid;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SendGrid.Helpers.Mail;

namespace ShoeDesignz.Models
{
    public class EmailSender : IEmailSender
    {
        private IConfiguration _configuration;

        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            SendGridClient client = new SendGridClient(_configuration["Sendgrid_Api_Key"]);

            SendGridMessage msg = new SendGridMessage();

            msg.SetFrom("noreply@ShoeDesignz.com", "ShoezDesign eCommerce Store");

            //msg.AddTo("castillocarlosr2@gmail.com");
            msg.AddTo(email);
            msg.SetSubject("Welcome to the Shoez Store");
            msg.AddContent(MimeType.Html, htmlMessage);

            //Set breakpoint here to DeBug
            //var response = await client.SendEmailAsync(msg);
            await client.SendEmailAsync(msg);
        }

        public EmailSender(IConfiguration configuration)
        {
            _configuration = configuration;
        }
    }
}
