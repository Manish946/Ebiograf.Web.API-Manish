using EBiograf.Web.Api.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EBiograf.Web.Api.Repository.UserRepo
{
    public interface IUserRepository
    {
        //Here we create methods that will be called in Class repository and data will be handled there.
        Task<List<User>> GetAllUsers();
    }
}
