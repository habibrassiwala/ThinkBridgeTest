// Controllers/DataController.cs
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DataController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetData()
        {
            string result = "Hello World";
            if (!string.IsNullOrEmpty(result))
                return Ok(new { message = "Data fetched", data = result });

            return BadRequest("No data");
        }
    }
}
