using MaxTechCS.Data.Global;
using MaxTechCS.Data.Global.Configuration;
using MaxTechCS.Utils;
using Microsoft.AspNetCore.Mvc;

namespace MaxTechCS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        [HttpGet("/task1")]
        public async Task<IActionResult> GetTask1(string input, int sortType)
        {
            try
            {
                ParallelVariables.ParallelCount++;
                if (ParallelVariables.ParallelCount > ParallelVariables.ParallelLimit) 
                {
                    return StatusCode(StatusCodes.Status503ServiceUnavailable, "Service is overloaded with requests. Try again later.");
                }
                var result = StringProcessor.ProcessString(input, sortType);
                ParallelVariables.ParallelCount--;
                return Ok(result);
            }
            catch (Exception ex)
            {
                ParallelVariables.ParallelCount--;
                return BadRequest(ex.Message);
            }
        }
    }
}
