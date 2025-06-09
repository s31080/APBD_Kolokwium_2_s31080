using System.ComponentModel.DataAnnotations;

namespace Kolokwium_s31080.Models;

public class Student
{
    [Key]
    public int Id { get; set; }
    
    [MaxLength(50)]
    public string FirstName { get; set; } = null!;
    
    [MaxLength(100)]
    public string LastName { get; set; } = null!;
    
    [MaxLength(150)]
    public string? Email { get; set; }
    
    public virtual ICollection<Enrollment> Enrollments { get; set; } = null!;
}