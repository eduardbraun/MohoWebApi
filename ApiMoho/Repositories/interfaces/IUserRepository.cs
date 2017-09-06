using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiMoho.Models;

namespace ApiMoho.Repositories.interfaces
{
    public interface IUserRepository
    {
        Task AddUserReview(UserReview userReview);
    }
}
