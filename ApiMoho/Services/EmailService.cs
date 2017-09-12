using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using ApiMoho.Settings;
using Microsoft.Extensions.Configuration;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace ApiMoho.Services
{
    public class EmailService
    {
        

        public EmailService()
        {
            
        }

        public async Task SendActivationEmail()
        {
//            var apiKey = AppConfig.SendGridApiKey;
//            var client = new SendGridClient(apiKey);
//            var from = new EmailAddress("donotreply@iknowwhatyouaredoing.com", "Secret");
//            var subject = "Ich weis was du gemacht hast gerade.";
//            var to = new EmailAddress("felixbraun1@yahoo.ca", "Felix Braun");
//            var plainTextContent = "mach das bitte nicht mehr";
//            var htmlContent = "<strong>mach das bitte nicht mehr</strong>";
//            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
//            var response = await client.SendEmailAsync(msg);
        }

        public async Task SendEmailToFreelancer(string fromEmail, string message, string toEmail, string toFullname)
        {
            try
            {
                var apiKey = AppConfig.SendGridApiKey;
                var client = new SendGridClient(apiKey);
                var from = new EmailAddress("donotreply@skillzas.com", "Skillzas");
                var subject = "A Person has contacted you regarding your listing!";
                var to = new EmailAddress(toEmail, toFullname);
                var plainTextContent = "A user has send you a message ragarding your ad ! \n " +
                                       "Please do not reply to this email. \n\n\n\n" +
                                       message +
                                       "\n\n\n" +
                                       "This message has been send from: " + fromEmail;
                var htmlContent = "A user has send you a message ragarding your ad ! \n " +
                                  "Please do not reply to this email. \n\n\n\n" +
                                  message +
                                  "\n\n\n" +
                                  "This message has been send from: " + fromEmail +
                                  "\n\n\n\n <strong> Your Skillzas team. </strong>";
                var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
                var response = await client.SendEmailAsync(msg);

                if ((int) response.StatusCode > 210)
                {
                  
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
                       

        }
    }
}
