using System;
using System.Collections.Generic;

namespace ApiMoho.Models
{
    public partial class UserReview
    {
        public int UserReviewId { get; set; }
        public bool? ReviewDeleted { get; set; }
        public string ReviewOwnerRefId { get; set; }
        public string UserRefId { get; set; }
        public string ReviewTitle { get; set; }
        public string ReviewDescription { get; set; }
        public DateTime? ReviewDate { get; set; }
        public string UpVoteNum { get; set; }
        public string ReviewUsername { get; set; }

        public AspNetUsers ReviewOwnerRef { get; set; }
        public AspNetUsers UserRef { get; set; }
    }
}
