using EBiograf.Web.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EBiograf.Web.Api.Services
{
    public interface IUserService
    {
        User Authenticate(string username, string password);
        Task<List<User>> GetAllUsers();
        User GetById(int id);
        User Create(User user, string password);
        void Update(User user, string password = null);
        void delete(int id);
    }
}
