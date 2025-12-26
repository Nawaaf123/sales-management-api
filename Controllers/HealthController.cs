using Microsoft.AspNetCore.Mvc;

namespace SalesManagement.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HealthController : ControllerBase
    {
        [HttpGet("db")]
        public IActionResult CheckDb()
        {
            return Ok(new { status = "api is healthy" });
        }
    }
}
