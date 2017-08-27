using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiMoho.Models.Dtos;
using ApiMoho.Models.Request;

namespace ApiMoho.Commands.Interfaces
{
    public interface IListingCommand
    {
        Task<UserListingDto> AddListingCommand(AddListingDto addListingDto, string fullName, string userId);
        Task<UserListingCollectionDto> GetAllListingsCommand();
        Task<UserListingCollectionDto> GetAllListingsForUserCommand(string userId);
        Task<UserListingDto> UpdateListing(UpdateListingRequest updateListingRequest,string userId);
    }
}
