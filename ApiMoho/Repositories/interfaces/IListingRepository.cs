using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiMoho.Models.Dtos;

namespace ApiMoho.Repositories.interfaces
{
    public interface IListingRepository
    {
        Task AddListing(AddListingDto addListingDto);
        Task RemoveListing(int enity);
    }
}
