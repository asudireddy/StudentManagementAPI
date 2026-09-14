namespace StudentMangementAPI.Models;

public class Enrollment
{
    public int Id { get; set; }

    public int StudentId { get; set; }

    public int CourseId { get; set; }

    public DateOnly EnrollmentDate { get; set; }

    public string Grade { get; set; } = string.Empty;

    public Student? Student { get; set; }

    public Course? Course { get; set; }
}