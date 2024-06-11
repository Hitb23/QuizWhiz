using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using server.DataLayer.DataContext;
using server.DataLayer.DTO;
using server.services.IServices;
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
        private readonly IAuthService _authService;
        

        public AuthController(ApplicationDbContext context, IConfiguration configuration, IAuthService authService)
        {
            _context = context;
            _configuration = configuration;
            _authService = authService;
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO LoginCredential)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var token = await _authService.AuthenticateUserAsync(LoginCredential);

            if (token == null)
            {
                return Unauthorized(new { message = "Invalid credentials" });
            }

            return Ok(new { token });

        }
    }
}
