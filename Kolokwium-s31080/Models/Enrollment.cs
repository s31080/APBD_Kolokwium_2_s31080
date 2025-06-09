using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Kolokwium_s31080.Models;

[Table("Enrollment")]
[PrimaryKey(nameof(StudentId), nameof(CourseId))]
public class Enrollment
{
    [Column("Student_Id")]
    public int StudentId { get; set; }
    
    [Column("Course_Id")]
    public int CourseId { get; set; }
    
    public DateTime EnrollmentDate { get; set; }
    
    [ForeignKey(nameof(StudentId))]
    public virtual Student Student { get; set; } = null!;
    
    [ForeignKey(nameof(CourseId))]
    public virtual Course Course { get; set; } = null!;
}