using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiMoho.Models.Dtos;

namespace ApiMoho.Commands.Interfaces
{
    public interface IListingCommand
    {
        Task<UserListingDto> AddListingCommand(AddListingDto addListingDto, string fullName, string userId);
        Task<UserListingCollectionDto> GetAllListingsCommand();
        Task<UserListingCollectionDto> GetAllListingsForUserCommand(string userId);
    }
}
