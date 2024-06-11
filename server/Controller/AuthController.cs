using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using server.DataLayer.DataContext;
using server.DataLayer.DTO;
using server.Helpers;
using System.Data;
using System.Linq;
namespace server.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;
        private readonly JwtHelper _jwtHelper;

        public AuthController(ApplicationDbContext context, IConfiguration configuration, JwtHelper jwtHelper)
        {
            _context = context;
            _configuration = configuration;
            _jwtHelper = jwtHelper;
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO LoginCredential)
        {
            
          var user = _context.Users
         .Where(u => u.Email == LoginCredential.Email && u.PasswordHash == LoginCredential.Password)
         .Include(u => u.Role) 
         .FirstOrDefault();

            if (user == null)
            {
                return Unauthorized();
            }         
           
            var token = _jwtHelper.GenerateJwtToken(LoginCredential.Email, LoginCredential.Password, user.Role.RoleName );

            return Ok(new { token });

        }
    }
}
