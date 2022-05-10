using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TeamAPI.Models;

namespace TeamAPI.Repositories
{
    public interface IUserRoleRepository
    {
        Task<IEnumerable<UserRole>> Get();
        Task<UserRole> Get(int id);
        Task<UserRole> Create(UserRole userRole);
        Task Update(UserRole userRole);
        Task Delete(int id);
    }
}
