﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiMoho.Models.Dtos;

namespace ApiMoho.Models.Response
{
    public class GetAllListingsResponse
    {
        public UserListingCollectionDto UserListingCollectionDto { get; set; }
    }
}
