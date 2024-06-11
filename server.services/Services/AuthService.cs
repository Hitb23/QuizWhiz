using server.DataLayer.DTO;
using server.DataLayer.Helpers;
using server.repository.IRepository;
using server.services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace server.services.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly JwtHelper _jwtHelper;

        public AuthService(IUserRepository userRepository, JwtHelper jwtHelper)
        {
            _userRepository = userRepository;
            _jwtHelper = jwtHelper;
        }

        public async Task<string> AuthenticateUserAsync(LoginDTO loginCredential)
        {
            var user = await _userRepository.GetUserByEmailAndPasswordAsync(loginCredential.Email, loginCredential.Password);

            if (user == null)
            {
                return null;
            }

            return _jwtHelper.GenerateJwtToken(user.Email, user.PasswordHash,user.Role.RoleName);
        }
    }
}
