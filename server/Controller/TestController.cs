using Microsoft.AspNetCore.Mvc;

namespace server.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController:ControllerBase
    {
        [HttpGet("get")]
        public IActionResult Get()
        {
            return Ok(new { message = "Hello from the backend!" });
        }

    }
}
