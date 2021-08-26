using EBiograf.Web.Api.Environment;
using EBiograf.Web.Api.Helper;
using EBiograf.Web.Api.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EBiograf.Web.Api.Services
{
    public class UserService : IUserService
    {
        private EBiografDbContext context;

        public UserService(EBiografDbContext _context)
        {
            context = _context;
        }
        public User Authenticate(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                return null;
            }
            var user = context.Users.SingleOrDefault(x => x.UserName == username);

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
            password = BCrypt.Net.BCrypt.HashPassword(password);
            return password;

        }

        public User Create(User user, string password)
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
            context.Users.Add(user);
            context.SaveChanges();
            return user;
        }

        public void delete(int id)
        {
            var user = context.Users.Find(id);
            if (user != null)
            {
                context.Users.Remove(user);
                context.SaveChanges();
            }
        }

        

        public User GetById(int id)
        {
            return context.Users.Find(id);
        }

        public void Update(User user, string password = null)
        {
            var Updateuser = context.Users.Find(user.UserID);
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
            context.Users.Update(Updateuser);
            context.SaveChanges();
        }

        public async Task<List<User>> GetAllUsers()
        {
            return await context.Users.ToListAsync();
        }
    }
}
