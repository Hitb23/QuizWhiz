using Microsoft.AspNetCore.Mvc;
using server.Auth;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace server.Controller
{
   
    [Route("api/[controller]")]
    [ApiController]
    public class ContestantController : ControllerBase
    {
        [HttpGet("testget")]
        [CustomAuthorize("contestant")]
        public IActionResult GetName()
        {
            return Ok(new {message="hello from contestant controller"});
        }
        
    }
}
