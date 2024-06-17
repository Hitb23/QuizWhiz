using Microsoft.EntityFrameworkCore;
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
        User GetUserByEmail(string email);
        User GetUserById(int id);

        Task<bool> IsEmailTaken(string email);
        Task<User> RegisterUser(User user);
        Task<User> IsValidUserName(string userName);

        public void UpdateUser(User user);
      
    }
}
