using Microsoft.EntityFrameworkCore;
using StudentMangementAPI.Models;

namespace StudentMangementAPI.Data;

public class StudentDbContext : DbContext
{
    public StudentDbContext(DbContextOptions<StudentDbContext> options)
        : base(options)
    {
    }

    public DbSet<Student> Students { get; set; }

    public DbSet<Course> Courses { get; set; }

    public DbSet<Enrollment> Enrollments { get; set; }

    public DbSet<Department> Departments { get; set; }
}