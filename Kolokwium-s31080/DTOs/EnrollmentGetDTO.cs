namespace Kolokwium_s31080.DTOs;

public class EnrollmentGetDto
{
    public StudentInfoDto Student { get; set; } = null!;
    public CourseInfoDto Course { get; set; } = null!;
    public DateTime EnrollmentDate { get; set; }
}

public class StudentInfoDto
{
    public int Id { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string? Email { get; set; }
}

public class CourseInfoDto
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public string Teacher { get; set; } = null!;
}