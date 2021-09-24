using EBiograf.Web.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EBiograf.Web.Api.Services
{
    public interface IUserService
    {
       public Task<User> Authenticate(string username, string password);
        public Task<IEnumerable<User>> GetAllUsers();
        public Task<User> GetById(int id);
        public Task<User> Create(User user, string password);
        public Task<User> Update(User user, string password = null);
        public Task<User> delete(int id);
    }
}
