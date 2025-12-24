using Dapper;
using Microsoft.AspNetCore.Connections;
using Microsoft.AspNetCore.Mvc;
using SalesManagement.Api.Data;

namespace SalesManagement.Api.Controllers
{
    [ApiController]
    [Route("api/health")]
    public class HealthController : ControllerBase
    {
        private readonly DbConnectionFactory _factory;

        public HealthController(DbConnectionFactory factory)
        {
            _factory = factory;
        }

        [HttpGet("db")]
        public async Task<IActionResult> CheckDb()
        {
            using var db = _factory.CreateConnection();
            var result = await db.ExecuteScalarAsync<int>("select 1");
            return Ok(new { database = "connected", result });
        }
    }
}
