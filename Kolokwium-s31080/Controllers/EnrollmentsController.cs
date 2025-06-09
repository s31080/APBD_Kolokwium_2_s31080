using Kolokwium_s31080.Services;
using Microsoft.AspNetCore.Mvc;

namespace Kolokwium_s31080.Controllers;


[ApiController]
[Route("api/[controller]")]
public class EnrollmentsController(IDbService service) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetEnrollments()
    {
        return Ok(await service.GetEnrollmentsAsync());
    }
}