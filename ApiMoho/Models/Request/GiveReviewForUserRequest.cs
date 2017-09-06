using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Rewrite.Internal.UrlMatches;

namespace ApiMoho.Models.Request
{
    public class GiveReviewForUserRequest
    {
        [Required]
        public string OwnerId { get; set; }
        public string ReviewTitle { get; set; }
        public string ReviewDescription { get; set; }
        [DefaultValue(0)]
        public int UpVotePoints { get; set; }
    }
}
