using server.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace server.repository.IRepository
{
    public interface IUserRepository
    {
        Task<User> GetUserByEmailAndPasswordAsync(string email, string password);

        Task<bool> IsEmailTaken(string email);
        Task<User> RegisterUser(User user);
      
    }
}
