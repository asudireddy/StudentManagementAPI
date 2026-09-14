using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentMangementAPI.Data;
using StudentMangementAPI.Models;

namespace StudentMangementAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StudentsController : ControllerBase
{
    private readonly StudentDbContext _context;

    public StudentsController(StudentDbContext context)
    {
        _context = context;
    }

    // GET: api/students
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Student>>> GetStudents()
    {
        return Ok(await _context.Students.ToListAsync());
    }

    // GET: api/students/1
    [HttpGet("{id:int}")]
    public async Task<ActionResult<Student>> GetStudent(int id)
    {
        Student? student = await _context.Students.FindAsync(id);

        if (student is null)
        {
            return NotFound(new
            {
                message = $"Student with ID {id} was not found."
            });
        }

        return Ok(student);
    }

    // POST: api/students
    [HttpPost]
    public async Task<ActionResult<Student>> CreateStudent(Student student)
    {
        _context.Students.Add(student);

        await _context.SaveChangesAsync();

        return CreatedAtAction(
            nameof(GetStudent),
            new { id = student.Id },
            student);
    }

    // PUT: api/students/1
    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateStudent(
        int id,
        Student updatedStudent)
    {
        Student? student = await _context.Students.FindAsync(id);

        if (student is null)
        {
            return NotFound(new
            {
                message = $"Student with ID {id} was not found."
            });
        }

        student.FirstName = updatedStudent.FirstName;
        student.LastName = updatedStudent.LastName;
        student.Email = updatedStudent.Email;
        student.Phone = updatedStudent.Phone;
        student.DateOfBirth = updatedStudent.DateOfBirth;
        student.EnrollmentDate = updatedStudent.EnrollmentDate;
        student.IsActive = updatedStudent.IsActive;
        student.DepartmentId = updatedStudent.DepartmentId;

        await _context.SaveChangesAsync();

        await _context.SaveChangesAsync();

        return NoContent();
    }

    // DELETE: api/students/1
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteStudent(int id)
    {
        Student? student = await _context.Students.FindAsync(id);

        if (student is null)
        {
            return NotFound(new
            {
                message = $"Student with ID {id} was not found."
            });
        }

        _context.Students.Remove(student);

        await _context.SaveChangesAsync();

        return NoContent();
    }
}