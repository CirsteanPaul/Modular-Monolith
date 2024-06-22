using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Modules.Test;

[ApiController]
[Route("api/test")]
public class TestController : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(typeof(Guid), StatusCodes.Status200OK)]
    public IActionResult AddComment()
    {
        return Ok(Guid.NewGuid());
    }
}