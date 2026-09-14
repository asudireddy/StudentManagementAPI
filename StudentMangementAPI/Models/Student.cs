namespace StudentMangementAPI.Models;

public class Student
{
    public int Id { get; set; }

    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string Phone { get; set; } = string.Empty;

    public DateOnly DateOfBirth { get; set; }

    public DateOnly EnrollmentDate { get; set; }

    public bool IsActive { get; set; }

    // Department relationship
    public int? DepartmentId { get; set; }

    public Department? Department { get; set; }
}