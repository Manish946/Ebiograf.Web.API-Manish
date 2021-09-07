using EBiograf.Web.Api.Environment;
using EBiograf.Web.Api.Helper;
using EBiograf.Web.Api.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EBiograf.Web.Api.Repository.UserRepo
{
    public class UserRepository : IUserRepository
    {
        private EBiografDbContext context;

        public UserRepository(EBiografDbContext _context)
        {
            context = _context;
        }
        public async Task<User> Authenticate(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                return null;
            }
            var user = await context.Users.SingleOrDefaultAsync(x => x.UserName == username);

            if (user == null)
            {
                return null;
            }

            if (!VerifyPasswordHash(password, user.Password))
            {
                return null;
            }
            return user;
        }
        // VerifyPasswordHash
        private static bool VerifyPasswordHash(string password, string UserPassword)
        {
            bool checkPassword = BCrypt.Net.BCrypt.Verify(password, UserPassword);
            return checkPassword;
        }
        //Create Password Hash
        private static string CreatePasswordHash(string password)
        {
            // Bcrypting using Bcrpyt
            password = BCrypt.Net.BCrypt.HashPassword(password);
            return password;

        }

        public async Task<User> Create(User user, string password)
        {
            if (string.IsNullOrWhiteSpace(password))
            {
                throw new AppException("Password is required");
            }
            if (context.Users.Any(x => x.UserName == user.UserName))
            {
                throw new AppException("Username \"" + user.UserName + "\" is already taken");
            }
            user.Password = CreatePasswordHash(password);
            user.DateCreated = DateTime.UtcNow;
            await context.Users.AddAsync(user);
            context.SaveChanges();
            return user;
        }

        public async Task<User> delete(int id)
        {
            var user = await context.Users.FindAsync(id);
            if (user != null)
            {
                context.Users.Remove(user);
                context.SaveChanges();
            }
            return user;
        }



        public async Task<User> GetById(int id)
        {
            return await context.Users.FindAsync(id);
        }

        public async Task<User> Update(User user, string password = null)
        {
            var Updateuser = await context.Users.FindAsync(user.UserID);
            if (Updateuser == null)
            {
                throw new AppException("User not found");
            }

            if (!string.IsNullOrWhiteSpace(user.UserName) && user.UserName != Updateuser.UserName)
            {
                // Throw error if the new username is already taken.
                if (context.Users.Any(x => x.UserName == user.UserName))
                {
                    throw new AppException("Username " + user.UserName + "is already taken");

                }
                Updateuser.UserName = user.UserName;
            }
            // update user properties if provided
            if (!string.IsNullOrWhiteSpace(user.FirstName))
            {
                Updateuser.FirstName = user.FirstName;
            }
            if (!string.IsNullOrWhiteSpace(user.LastName))
            {
                Updateuser.LastName = user.LastName;
            }
            // update password if provided
            if (!string.IsNullOrWhiteSpace(password))
            {
                var newPassword = CreatePasswordHash(password);
                Updateuser.Password = newPassword;
            }
            if (!string.IsNullOrWhiteSpace(user.EmailAddress))
            {
                Updateuser.EmailAddress = user.EmailAddress;

            }
            if (!string.IsNullOrWhiteSpace(user.Phone))
            {
                Updateuser.Phone = user.Phone;

            }
            context.Users.Update(Updateuser);
            context.SaveChanges();
            return Updateuser;
        }

        public async Task<List<User>> GetAllUsers()
        {
            return await context.Users.ToListAsync();
        }
    }
}
