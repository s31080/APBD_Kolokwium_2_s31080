using Kolokwium_s31080.Models;
using Microsoft.EntityFrameworkCore;

namespace Kolokwium_s31080.Data;

public class AppDbContext : DbContext
{
    public DbSet<Student> Students { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<Enrollment> Enrollments { get; set; }

    public AppDbContext(DbContextOptions options) : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        var students = new List<Student>
        {
            new()
            {
                Id = 1,
                FirstName = "Anna",
                LastName = "Nowak",
                Email = "anna.nowak@example.edu"
            },
            new()
            {
                Id = 2,
                FirstName = "Tomasz",
                LastName = "Wiśniewski",
                Email = "tomasz.w@example.edu"
            }
        };

        var courses = new List<Course>
        {
            new()
            {
                Id = 101,
                Title = "Wprowadzenie do Algorytmów",
                Credits = "6 ECTS",
                Teacher = "dr Kowalski"
            },
            new()
            {
                Id = 102,
                Title = "Bazy Danych",
                Credits = "5 ECTS",
                Teacher = "mgr Nowicka"
            }
        };

        var enrollments = new List<Enrollment>
        {
            new()
            {
                StudentId = 1,
                CourseId = 101,
                EnrollmentDate = new DateTime(2024, 10, 1, 10, 0, 0)
            },
            new()
            {
                StudentId = 2,
                CourseId = 102,
                EnrollmentDate = new DateTime(2024, 10, 2, 9, 30, 0)
            }
        };
        
        modelBuilder.Entity<Student>().HasData(students);
        modelBuilder.Entity<Course>().HasData(courses);
        modelBuilder.Entity<Enrollment>().HasData(enrollments);
    }
}