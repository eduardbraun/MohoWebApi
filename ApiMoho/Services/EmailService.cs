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

                var from2 = new EmailAddress(fromEmail);

                var msg2 = MailHelper.CreateSingleEmail(from, from2, "This is a copy from your message.",
                    plainTextContent, htmlContent);

                var response2 = await client.SendEmailAsync(msg2);

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
