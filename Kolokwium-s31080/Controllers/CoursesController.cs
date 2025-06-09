using Kolokwium_s31080.DTOs;
using Kolokwium_s31080.Services;
using Microsoft.AspNetCore.Mvc;

namespace Kolokwium_s31080.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CoursesController(IDbService service) : ControllerBase
{
    [HttpPost("with-enrollments")]
    public async Task<IActionResult> CreaateCourseWithEnrollments([FromBody] CourseWithEnrollmentsCreateDto courseInfo)
    {
        var result = await service.CreateCourseWithEnrollmentsAsync(courseInfo);
        return Ok(result);
    }
    
}