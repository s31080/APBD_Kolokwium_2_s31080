namespace Kolokwium_s31080.DTOs;

public class CourseWithEnrollmentsResponseDto
{
    public string Message { get; set; } = null!;
    public CourseResponseDto Course { get; set; } = null!;
    public ICollection<EnrollmentResponseDto> Enrollments { get; set; } = null!;
}

public class CourseResponseDto
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public string? Credits { get; set; }
    public string Teacher { get; set; } = null!;
}

public class EnrollmentResponseDto
{
    public int StudentId { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string? Email { get; set; }
    public DateTime EnrollmentDate { get; set; }
}