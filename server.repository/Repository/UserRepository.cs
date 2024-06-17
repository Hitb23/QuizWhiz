using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using server.DataLayer.DataContext;
using server.DataLayer.Helpers;
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
        
       
        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
            
        }

        public async Task<User> IsValidUserName(string userName)
        {
            try
            {
                var user = await _context.Users.FirstOrDefaultAsync(r => r.Username == userName);
                return user;
            }
            catch (Exception exp)
            {
                return null;
            }
        }
        public async Task<User> GetUserByEmailAndPasswordAsync(string email, string password)
        {
            try
            {
                var user = await _context.Users
                    .Include(u => u.Role)
                    .Where(u => u.Email == email)                  
                    .FirstOrDefaultAsync();

                if(user != null ) 
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
        public async Task<bool> IsEmailTaken(string email)
        {
            return await _context.Users.AnyAsync(u => u.Email == email);
        }

        public async Task<User> RegisterUser(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

      
    }
}
