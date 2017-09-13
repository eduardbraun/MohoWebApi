using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiMoho.Services
{
    public interface ILogService
    {
        Task AddSendEmailLog(string message, string fromEmail, string toEmail, string recipientUserId);
        Task AddUserLog(string userId, string logType, string logMessage);
    }
}
