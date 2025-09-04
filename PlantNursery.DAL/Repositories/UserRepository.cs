using Microsoft.EntityFrameworkCore;
using PlantNursery.DAL.Context;
using PlantNursery.DAL.Entities;
using PlantNursery.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlantNursery.DAL.Repositories
{
    public class UserRepository :IUserRepository
    {
        public readonly PlantNurseryDbContext _context;

        public UserRepository(PlantNurseryDbContext context)
        {
            _context = context;
        }

        public async Task<User> PostUser(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<User> LoginUser(string username, string passwordHash)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Username == username && u.PasswordHash == passwordHash);
        }

        public async Task<User?> UpdateUser(int id, User updatedUser)
        {
            var existingUser = await _context.Users.FindAsync(id);
            if (existingUser == null)
            {
                return null; // or throw an exception
            }
            existingUser.Username = updatedUser.Username;
            existingUser.PasswordHash = updatedUser.PasswordHash;
            existingUser.Email = updatedUser.Email;
            existingUser.FirstName = updatedUser.FirstName;
            existingUser.LastName = updatedUser.LastName;
            existingUser.Address = updatedUser.Address;
            existingUser.Phone = updatedUser.Phone;

            _context.Users.Update(existingUser);
            await _context.SaveChangesAsync();
            return existingUser;
        }
    }
}
