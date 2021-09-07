using EBiograf.Web.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EBiograf.Web.Api.Services
{
    public interface IUserService
    {
        Task<User> Authenticate(string username, string password);
        Task<List<User>> GetAllUsers();
        Task<User> GetById(int id);
        Task<User> Create(User user, string password);
        Task<User> Update(User user, string password = null);
        Task<User> delete(int id);
    }
}
