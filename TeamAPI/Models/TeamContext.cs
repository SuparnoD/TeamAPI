using System;
using Microsoft.EntityFrameworkCore;

namespace TeamAPI.Models
{
    public class TeamContext : DbContext
    {
        public TeamContext(DbContextOptions<TeamContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Team> Team { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<User> User { get; set; }
    }
}
