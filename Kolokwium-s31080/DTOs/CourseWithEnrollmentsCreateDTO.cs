using System.ComponentModel.DataAnnotations;

namespace Kolokwium_s31080.DTOs;

public class CourseWithEnrollmentsCreateDto
{
    [Required]
    [MaxLength(200)]
    public string Title { get; set; } = null!;
    
    [MaxLength(50)]
    public string? Credits { get; set; }
    
    [Required]
    [MaxLength(100)]
    public string Teacher { get; set; } = null!;
    
    public ICollection<StudentEnrollmentDto> Students { get; set; } = null!;
}

public class StudentEnrollmentDto
{
    [Required]
    [MaxLength(50)]
    public string FirstName { get; set; } = null!;
    
    [Required]
    [MaxLength(50)]
    public string LastName { get; set; } = null!;
    
    [MaxLength(100)]
    public string? Email { get; set; }
}