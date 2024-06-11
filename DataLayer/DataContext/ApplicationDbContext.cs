using Microsoft.EntityFrameworkCore;
using server.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace server.DataLayer.DataContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<ResetPassword> ResetPasswords { get; set; }
        public DbSet<Contestant> Contestants { get; set; }
        public DbSet<Admin> Admins { get; set; }
    }
}
