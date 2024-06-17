using Microsoft.AspNetCore.Mvc;
using server.DataLayer.DTO;
using server.repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace server.repository.IRepository
{
    public interface IUserServices
    {
        Task<IActionResult> Register(UserDTO newUser);
        Task<bool> checkUserName(string userName);

        public bool ResetPassword(string token, string newPassword);

        public bool ValidateResetToken(string token);
       

    }
}
