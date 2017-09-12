using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiMoho.Models.ListingRequest
{
    public class SendEmailToFreelancerRequest
    {
        [Required (ErrorMessage = "Email is Required")]
        public string FromEmail { get; set; }

        [Required (ErrorMessage = "Your message can not be empty!")]
        public string Message { get; set; }

        [Required]
        public string ListingId { get; set; }

        [Required]
        public string FreeLancerUserId { get; set; }
    }
}
