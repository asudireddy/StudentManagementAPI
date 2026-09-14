using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentMangementAPI.Data;
using StudentMangementAPI.Models;

namespace StudentMangementAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EnrollmentsController : ControllerBase
{
    private readonly StudentDbContext _context;

    public EnrollmentsController(StudentDbContext context)
    {
        _context = context;
    }

    // GET: api/enrollments
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Enrollment>>> GetEnrollments()
    {
        var enrollments = await _context.Enrollments
            .Include(e => e.Student)
            .Include(e => e.Course)
            .ToListAsync();

        return Ok(enrollments);
    }

    // GET: api/enrollments/1
    [HttpGet("{id:int}")]
    public async Task<ActionResult<Enrollment>> GetEnrollment(int id)
    {
        var enrollment = await _context.Enrollments
            .Include(e => e.Student)
            .Include(e => e.Course)
            .FirstOrDefaultAsync(e => e.Id == id);

        if (enrollment is null)
        {
            return NotFound(new
            {
                message = $"Enrollment with ID {id} was not found."
            });
        }

        return Ok(enrollment);
    }

    // POST: api/enrollments
    [HttpPost]
    public async Task<ActionResult<Enrollment>> CreateEnrollment(Enrollment enrollment)
    {
        var studentExists = await _context.Students
            .AnyAsync(s => s.Id == enrollment.StudentId);

        if (!studentExists)
        {
            return BadRequest(new
            {
                message = "Student does not exist."
            });
        }

        var courseExists = await _context.Courses
            .AnyAsync(c => c.Id == enrollment.CourseId);

        if (!courseExists)
        {
            return BadRequest(new
            {
                message = "Course does not exist."
            });
        }

        _context.Enrollments.Add(enrollment);

        await _context.SaveChangesAsync();

        return CreatedAtAction(
            nameof(GetEnrollment),
            new { id = enrollment.Id },
            enrollment);
    }
    // PUT: api/enrollments/1
    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateEnrollment(
        int id,
        Enrollment updatedEnrollment)
    {
        var enrollment = await _context.Enrollments.FindAsync(id);

        if (enrollment is null)
        {
            return NotFound(new
            {
                message = $"Enrollment with ID {id} was not found."
            });
        }

        // Check that the student exists
        var studentExists = await _context.Students
            .AnyAsync(s => s.Id == updatedEnrollment.StudentId);

        if (!studentExists)
        {
            return BadRequest(new
            {
                message = "Student does not exist."
            });
        }

        // Check that the course exists
        var courseExists = await _context.Courses
            .AnyAsync(c => c.Id == updatedEnrollment.CourseId);

        if (!courseExists)
        {
            return BadRequest(new
            {
                message = "Course does not exist."
            });
        }

        enrollment.StudentId = updatedEnrollment.StudentId;
        enrollment.CourseId = updatedEnrollment.CourseId;
        enrollment.EnrollmentDate = updatedEnrollment.EnrollmentDate;
        enrollment.Grade = updatedEnrollment.Grade;

        await _context.SaveChangesAsync();

        return NoContent();
    }

    // DELETE: api/enrollments/1
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteEnrollment(int id)
    {
        var enrollment = await _context.Enrollments.FindAsync(id);

        if (enrollment is null)
        {
            return NotFound(new
            {
                message = $"Enrollment with ID {id} was not found."
            });
        }

        _context.Enrollments.Remove(enrollment);

        await _context.SaveChangesAsync();

        return NoContent();
    }
}