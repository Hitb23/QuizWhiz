using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using server.DataLayer.DataContext;
using server.DataLayer.Models;
using server.repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace server.repository.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;
       
        public UserRepository(ApplicationDbContext context, ILogger<UserRepository> logger)
        {
            _context = context;
            
        }

        public async Task<User> GetUserByEmailAndPasswordAsync(string email, string password)
        {
            try
            {
                var user = await _context.Users
                    .Where(u => u.Email == email && u.PasswordHash == password)
                    .Include(u => u.Role)
                    .FirstOrDefaultAsync();

                if(user != null)
                {
                    return user;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
               Console.WriteLine(ex);
                return null;
            }

        }

    }
}
