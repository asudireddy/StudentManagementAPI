namespace StudentMangementAPI.Models;

public class Course
{
    public int Id { get; set; }

    public string CourseCode { get; set; } = string.Empty;

    public string CourseName { get; set; } = string.Empty;

    public int Credits { get; set; }

    // Nullable foreign key to Department
    public int? DepartmentId { get; set; }

    // Navigation property
    public Department? Department { get; set; }
}
