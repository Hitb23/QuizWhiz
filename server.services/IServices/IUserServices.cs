using Microsoft.AspNetCore.Mvc;
using server.DataLayer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace server.repository.IRepository
{
    public interface IUserServices
    {
        Task<IActionResult> Register(UserDto newUser);
    }
}
