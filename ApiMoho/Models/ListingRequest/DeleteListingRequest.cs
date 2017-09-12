using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiMoho.Models
{
    public class DeleteListingRequest
    {
        [Required]
        public int UserListingId { get; set; }
        [Required]
        public string OwnerId { get; set; }
    }
}
