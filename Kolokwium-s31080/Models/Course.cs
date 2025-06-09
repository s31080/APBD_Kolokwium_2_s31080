using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kolokwium_s31080.Models;

[Table("Course")]
public class Course
{
    [Key]
    public int Id { get; set; }
    
    [MaxLength(150)]
    public string Title { get; set; } = null!;
    
    [MaxLength(300)]
    public string? Credits { get; set; }
    
    [MaxLength(100)]
    public string Teacher { get; set; } = null!;
    
    public virtual ICollection<Enrollment> Enrollments { get; set; } = null!;
}