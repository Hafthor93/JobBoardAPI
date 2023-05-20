using System;
using System.Threading.Tasks;
using JobboardAPI.Models;
using JobBoardAPI.Data.Interfaces;
using JobBoardAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JobBoardAPI
{
    public class UserRepository : IUserRepository
    {
        private AppDbContext _dbContext;

        public UserRepository(AppDbContext context)
        {
            _dbContext = context;
        }

        public async Task<User> Register(User user)
        {
            var existingUser = await _dbContext.Users.FirstOrDefaultAsync(u => u.Username == user.Username);
            if (existingUser != null)
            {
                throw new Exception("Username already exists");
            }

            _dbContext.Users.Add(user);
            await _dbContext.SaveChangesAsync();
            return user;
        }

        public async Task<User> Authenticate(string username, string password)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Username == username && u.Password == password);
            if (user == null)
            {
                throw new Exception("Username or password is incorrect");
            }

            return user;
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return await _dbContext.Users.ToListAsync();
        }

        public async Task<User> GetUserById(int id)
        {
            var user = await _dbContext.Users.FindAsync(id);
            if (user == null)
            {
                throw new Exception($"User with id {id} not found");
            }

            return user;
        }

        public async Task<User> UpdateUser(User user)
        {
            var existingUser = await _dbContext.Users.FindAsync(user.Id);
            if (existingUser == null)
            {
                throw new Exception($"User with id {user.Id} not found");
            }

            existingUser.Username = user.Username;
            existingUser.Password = user.Password; // You may want to hash the password here instead of storing it in plain text

            _dbContext.Users.Update(existingUser);
            await _dbContext.SaveChangesAsync();
            return existingUser;
        }

        public async Task DeleteUser(int id)
        {
            var user = await _dbContext.Users.FindAsync(id);
            if (user == null)
            {
                throw new Exception($"User with id {id} not found");
            }

            _dbContext.Users.Remove(user);
            await _dbContext.SaveChangesAsync();
        }
    }
}
