using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiMoho.Models.Dtos
{
    public class UserProfileReviewDto
    {
        public string OwnerRefId { get; set; }
        public string UserRefRefId { get; set; }
        public string ReviewTitle { get; set; }
        public string ReviewDescription { get; set; }
        public int UpVotes { get; set; }
        public DateTime? ReviewDateTime { get; set; }
        public string Username { get; set; }
    }
}
