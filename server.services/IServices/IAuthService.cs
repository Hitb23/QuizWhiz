using server.DataLayer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace server.services.IServices
{
    public interface IAuthService
    {
        Task<string> AuthenticateUserAsync(LoginDTO loginCredential);
    }
}
