using Microsoft.AspNetCore.Mvc;
using server.DataLayer.DataContext;
using server.DataLayer.DTO;
using server.DataLayer.Helpers;
using server.DataLayer.Models;
using server.repository.IRepository;
using server.repository.Repository;
using server.Auth;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace server.Controller
{

    [Route("api/[controller]")]
    [ApiController]
   
    public class UserController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly HashingHelper _hashingHelper;
        private readonly IUserServices  _userServices;
        public UserController(ApplicationDbContext context, HashingHelper hashingHelper, IUserServices userServices)
        {
            _context = context;
            _hashingHelper = hashingHelper;
            _userServices = userServices;

        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserDTO newUser)
        {           
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var result = await _userServices.Register(newUser);
                return result;
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

    }
}
