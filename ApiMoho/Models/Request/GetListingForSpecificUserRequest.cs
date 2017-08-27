﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiMoho.Models.Request
{
    public class GetListingForSpecificUserRequest
    {
        [Required]
        public string UserId { get; set; }
    }
}
