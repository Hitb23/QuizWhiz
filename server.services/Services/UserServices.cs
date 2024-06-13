﻿using Microsoft.AspNetCore.Mvc;
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
                    Username = newUser.Email.Substring(0, newUser.Email.IndexOf('@')),
                    PasswordHash = hashedPassword,
                    CreatedDate = DateTime.UtcNow,
                };

                var registeredUser = await _userRepository.RegisterUser(user);

                var contestant = new Contestant
                {
                    UserId = registeredUser.UserId,
                    Email = registeredUser.Email,
                   CreatedDate = DateTime.UtcNow,
                   ModifiedDate = DateTime.UtcNow
                };

                // Example of further logic with contestant, if needed
               var AddedContestant =await _userRepository.AddContestant(contestant);

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
    }
}
