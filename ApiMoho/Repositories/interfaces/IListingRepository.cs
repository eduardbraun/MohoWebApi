using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiMoho.Models;
using ApiMoho.Models.Dtos;
using ApiMoho.Models.Request;

namespace ApiMoho.Repositories.interfaces
{
    public interface IListingRepository
    {
        Task<UserListings> AddListing(UserListings userListings);
        Task RemoveListing(int enity);
        Task<List<UserListings>> GetAll();
        Task<UserListings> GetById(int id);
        Task<List<UserListings>> GetAllForUser(string ownerId);
        Task<UserListings> Update(UserListings userListings, string ownerId);
        Task<List<CountrySelectionTable>> GetAllCounties();
        Task<List<ProvinceSelectionTable>> GetAllProvinces();
        Task<List<CitySeleectionTable>> GetAllCities();
        Task<List<ListingSelectionTable>> GetAllListings();
        Task DeleteListing(int listingId, string ownderId);
        Task SetListingStatus(int listingId, string ownderId, bool enabled);
        Task<List<UserListings>> SearchFilter(SearchListingRequest searchListingRequest);
    }
}
