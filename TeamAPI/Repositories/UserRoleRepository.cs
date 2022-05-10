using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TeamAPI.Models;

namespace TeamAPI.Repositories
{
    public class UserRoleRepository : IUserRoleRepository
    {
        private readonly TeamContext _context;

        public UserRoleRepository(TeamContext context)
        {
            _context = context;
        }

        public async Task<UserRole> Create(UserRole userRole)
        {
            _context.Add(userRole);
            await _context.SaveChangesAsync();

            return userRole;
        }

        public async Task Delete(int id)
        {
            var userRoleToDelete = await _context.UserRoles.FindAsync(id);
            _context.UserRoles.Remove(userRoleToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<UserRole>> Get()
        {
            return await _context.UserRoles.ToListAsync();
        }

        public async Task<UserRole> Get(int id)
        {
            return await _context.UserRoles.FindAsync(id);
        }

        public async Task Update(UserRole userRole)
        {
            _context.Entry(userRole).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
