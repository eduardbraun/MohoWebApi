using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiMoho.Models.Dtos;

namespace ApiMoho.Commands.Interfaces
{
    interface IListingCommand
    {
        Task AddListingCommand(AddListingDto addListingDto);
    }
}
