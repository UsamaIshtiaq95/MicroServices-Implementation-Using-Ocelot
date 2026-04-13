using Microsoft.AspNetCore.Mvc;

namespace UserApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public abstract class BaseController : ControllerBase
{
    protected IActionResult HandleResult<T>(T result)
    {
        if (result == null)
            return NotFound(new { message = "Resource not found" });
        
        return Ok(result);
    }

    protected IActionResult HandleCreateResult<T>(T result, string message = "Created successfully")
    {
        if (result == null)
            return BadRequest(new { message = "Failed to create resource" });
        
        return Created("", new { message, data = result });
    }

    protected IActionResult HandleDeleteResult(string message = "Deleted successfully")
    {
        return Ok(new { message });
    }
}
