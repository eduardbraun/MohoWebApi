using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiMoho.Models;

namespace ApiMoho.Services
{
    public class LogService : ILogService
    {
        public LogService()
        {
            
        }

        public async Task AddSendEmailLog(string message, string fromEmail, string toEmail, string recipientUserId)
        {
            try
            {
                using (var context  = new ApiMohoContext())
                {
                    var log = new SendEmailLog()
                    {
                        Message = message,
                        FromEmail = fromEmail,
                        RecipientUserId = recipientUserId,
                        ToEmail = toEmail
                    };

                    await context.AddAsync(log);
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task AddUserLog(string userId, string logType, string logMessage)
        {
            try
            {
                using (var context = new ApiMohoContext())
                {
                    var log = new UserLogs()
                    {
                        UserId = userId, 
                        LogType = logType,
                        LogMessage = logMessage
                    };

                    await context.AddAsync(log);
                    await context.SaveChangesAsync();
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
