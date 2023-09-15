using MaxTechCS.Utils;
using Microsoft.AspNetCore.Mvc;

namespace MaxTechCS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        [HttpGet("/task1")]
        public async Task<IActionResult> GetTask1(string input)
        {
            var result = StringProcessor.ProcessString(input);
            return Ok(result);
        }
    }
}
