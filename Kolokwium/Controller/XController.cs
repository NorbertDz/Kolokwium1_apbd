using Kolokwium.Service;
using Microsoft.AspNetCore.Mvc;

namespace Kolokwium.Controller;

[Route("api/[controller]")]
[ApiController]
public class XController : ControllerBase
{
    private readonly IXService _animalsRepository;
    public XController(IXService animalsRepository)
    {
        _animalsRepository = animalsRepository;
    }

    [HttpGet("")]
    public async Task<IActionResult> Get()
    {
        return Ok();
    }

    [HttpPost("")]
    public async Task<IActionResult> add() 
    {
        return Ok();
    }

    [HttpPut("")]
    public async Task<IActionResult> update()
    {
        return Ok();
    }

    [HttpDelete("")]
    public async Task<IActionResult> delete()
    {
        return Ok();
    }
}