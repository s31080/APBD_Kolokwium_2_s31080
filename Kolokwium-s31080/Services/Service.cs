using Kolokwium_s31080.Data;
using Kolokwium_s31080.DTOs;
using Kolokwium_s31080.Models;
using Microsoft.EntityFrameworkCore;

namespace Kolokwium_s31080.Services;

public interface IDbService
{
    public Task<ICollection<EnrollmentGetDto>> GetEnrollmentsAsync();
    public Task<CourseWithEnrollmentsResponseDto> CreateCourseWithEnrollmentsAsync(CourseWithEnrollmentsCreateDto courseData);
}

public class DbService(AppDbContext data) : IDbService
{
    public async Task<ICollection<EnrollmentGetDto>> GetEnrollmentsAsync()
    {
        return await data.Enrollments
            .Select(e => new EnrollmentGetDto
            {
                Student = new StudentInfoDto
                {
                    Id = e.Student.Id,
                    FirstName = e.Student.FirstName,
                    LastName = e.Student.LastName,
                    Email = e.Student.Email
                },
                Course = new CourseInfoDto
                {
                    Id = e.Course.Id,
                    Title = e.Course.Title,
                    Teacher = e.Course.Teacher
                },
                EnrollmentDate = e.EnrollmentDate
            }).ToListAsync();
    }

    public async Task<CourseWithEnrollmentsResponseDto> CreateCourseWithEnrollmentsAsync(CourseWithEnrollmentsCreateDto courseData)
    {
        var course = new Course
        {
            Title = courseData.Title,
            Credits = courseData.Credits,
            Teacher = courseData.Teacher
        };

        await data.Courses.AddAsync(course);
        await data.SaveChangesAsync();

        var enrollmentResponses = new List<EnrollmentResponseDto>();
        var enrollmentDate = DateTime.Now;

        foreach (var studentDto in courseData.Students)
        {
            var existingStudent = await data.Students
                .FirstOrDefaultAsync(s => s.FirstName == studentDto.FirstName && 
                                         s.LastName == studentDto.LastName && 
                                         s.Email == studentDto.Email);

            Student student;
            if (existingStudent != null)
            {
                student = existingStudent;
            }
            else
            {
                student = new Student
                {
                    FirstName = studentDto.FirstName,
                    LastName = studentDto.LastName,
                    Email = studentDto.Email
                };
                await data.Students.AddAsync(student);
                await data.SaveChangesAsync();
            }

            var enrollment = new Enrollment
            {
                StudentId = student.Id,
                CourseId = course.Id,
                EnrollmentDate = enrollmentDate
            };

            await data.Enrollments.AddAsync(enrollment);

            enrollmentResponses.Add(new EnrollmentResponseDto
            {
                StudentId = student.Id,
                FirstName = student.FirstName,
                LastName = student.LastName,
                Email = student.Email,
                EnrollmentDate = enrollmentDate
            });
        }

        await data.SaveChangesAsync();

        return new CourseWithEnrollmentsResponseDto
        {
            Message = "Kurs został utworzony i studenci zostali zapisani.",
            Course = new CourseResponseDto
            {
                Id = course.Id,
                Title = course.Title,
                Credits = course.Credits,
                Teacher = course.Teacher
            },
            Enrollments = enrollmentResponses
        };
    }
}