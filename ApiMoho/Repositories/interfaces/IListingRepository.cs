using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiMoho.Models;
using ApiMoho.Models.Dtos;

namespace ApiMoho.Repositories.interfaces
{
    public interface IListingRepository
    {
        Task<UserListings> AddListing(UserListings userListings);
        Task RemoveListing(int enity);
        Task<List<UserListings>> GetAll();
    }
}
