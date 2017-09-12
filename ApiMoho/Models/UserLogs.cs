using System;
using System.Collections.Generic;

namespace ApiMoho.Models
{
    public partial class UserLogs
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string LogType { get; set; }
        public string LogMessage { get; set; }
        public DateTime LogDate { get; set; }

        public AspNetUsers User { get; set; }
    }
}
