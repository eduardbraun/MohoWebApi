using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiMoho.Models;
using ApiMoho.Models.Dtos;
using ApiMoho.Models.ListingRequest;
using ApiMoho.Models.Request;
using ApiMoho.Models.Response;

namespace ApiMoho.Commands.Interfaces
{
    public interface IListingCommand
    {
        Task<UserListingDto> AddListingCommand(AddListingDto addListingDto, string fullName, string userId);
        Task<UserListingCollectionDto> GetAllListingsCommand();
        Task<UserListingCollectionDto> GetAllListingsForUserCommand(string userId);
        Task<UserListingDto> UpdateListing(UpdateListingRequest updateListingRequest,string userId);
        Task DeleteListing(DeleteListingRequest deleteListingRequest,string userId);
        Task SetListingStatus(SetListingEnabledRequest setListingEnabledRequest,string userId);
        Task<GetFilterListResponse> GetFilterList();
        Task<UserListingCollectionDto> SearchFilterList(SearchListingRequest searchListingRequest);
        Task SendEmailToFreelancer(SendEmailToFreelancerRequest sendEmailToFreelancerRequest, UserModel freelancerUser);
    }
}
