using Microsoft.AspNetCore.Mvc;
using server.DataLayer.DTO;
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
    public class UserServices : IUserServices
    {
        private readonly IUserRepository _userRepository;
        private readonly HashingHelper _hashingHelper;

        public UserServices(IUserRepository userRepository, HashingHelper hashingHelper)
        {
            _userRepository = userRepository;
            _hashingHelper = hashingHelper;
        }
        public async Task<IActionResult> Register(UserDTO newUser)
        {
            try
            {
                if (await _userRepository.IsEmailTaken(newUser.Email))
                {
                    return new ConflictObjectResult(new { message = "Email is already registered." });
                }

                string hashedPassword = _hashingHelper.HashPassword(newUser.Password);

                var user = new User
                {
                  
                    Email = newUser.Email,
                    Username = newUser.UserName,
                    PasswordHash = hashedPassword,
                    CreatedDate = DateTime.UtcNow,
                };

                var registeredUser = await _userRepository.RegisterUser(user);

                

                // Example of further logic with contestant, if needed
              

                return new OkObjectResult(new { message = "Registration successful." });
            }
            catch (Exception ex)
            {
                return new ObjectResult(new { message = $"Internal server error: {ex.Message}" })
                {
                    StatusCode = 500
                };
            }
        }

        public async Task<bool> checkUserName(string userName)
        {
            try
            {
                var user = _userRepository.IsValidUserName(userName);
                return user.Result == null;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
