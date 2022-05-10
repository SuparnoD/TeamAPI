using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TeamAPI.Models;

namespace TeamAPI.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly TeamContext _context;

        public UserRepository(TeamContext context)
        {
            _context = context;
        }

        public async Task<User> Create(User user)
        {
            _context.Add(user);
            await _context.SaveChangesAsync();

            return user;
        }

        public async Task Delete(int id)
        {
            var userToDelete = await _context.User.FindAsync(id);
            _context.User.Remove(userToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<User>> Get()
        {
            return await _context.User.ToListAsync();
        }

        public async Task<User> Get(int id)
        {
            return await _context.User.FindAsync(id);
        }

        public async Task Update(User user)
        {
            _context.Entry(user).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
