using EBiograf.Web.Api.Environment;
using EBiograf.Web.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EBiograf.Web.Api.Repository.UserRepo
{
    public class UserRepository : IUserRepository
    {
        private readonly EBiografDbContext context;
        // Readonly bestpractice to prevent accident changes.

        public UserRepository(EBiografDbContext _context)
        {
            context = _context;
        }
        public async Task<List<User>> GetAllUsers()
        {
            return await context.Users.ToListAsync();
        }
    }
}
