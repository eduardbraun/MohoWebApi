using System;
using System.Collections.Generic;

namespace ApiMoho.Models
{
    public partial class SendEmailLog
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public string FromEmail { get; set; }
        public string ToEmail { get; set; }
        public DateTime SendDate { get; set; }
        public string RecipientUserId { get; set; }

        public AspNetUsers RecipientUser { get; set; }
    }
}
