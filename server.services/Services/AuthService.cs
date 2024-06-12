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
        private readonly HashingHelper _hashingHelper;

        public AuthService(IUserRepository userRepository, JwtHelper jwtHelper, HashingHelper hashingHelper)
        {
            _userRepository = userRepository;
            _jwtHelper = jwtHelper;
            _hashingHelper = hashingHelper;
        }

        public async Task<string> AuthenticateUserAsync(LoginDTO loginCredential)
        {
            var user = await _userRepository.GetUserByEmailAndPasswordAsync(loginCredential.Email, loginCredential.Password);

            if (user == null || !_hashingHelper.VerifyPassword(loginCredential.Password, user.PasswordHash))
            {
                return null;
            }

            return _jwtHelper.GenerateJwtToken(user.Email, user.PasswordHash,user.Role.RoleName);
        }
    }
}
