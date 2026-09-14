using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentMangementAPI.Data;
using StudentMangementAPI.Models;

namespace StudentMangementAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CoursesController : ControllerBase
{
    private readonly StudentDbContext _context;

    public CoursesController(StudentDbContext context)
    {
        _context = context;
    }

    // GET: api/courses
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Course>>> GetCourses()
    {
        var courses = await _context.Courses.ToListAsync();
        return Ok(courses);
    }

    // GET: api/courses/1
    [HttpGet("{id:int}")]
    public async Task<ActionResult<Course>> GetCourse(int id)
    {
        var course = await _context.Courses.FindAsync(id);

        if (course is null)
        {
            return NotFound(new
            {
                message = $"Course with ID {id} was not found."
            });
        }

        return Ok(course);
    }

    // POST: api/courses
    [HttpPost]
    public async Task<ActionResult<Course>> CreateCourse(Course course)
    {
        _context.Courses.Add(course);
        await _context.SaveChangesAsync();

        return CreatedAtAction(
            nameof(GetCourse),
            new { id = course.Id },
            course);
    }

    // PUT: api/courses/1
    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateCourse(int id, Course updatedCourse)
    {
        var course = await _context.Courses.FindAsync(id);

        if (course is null)
        {
            return NotFound(new
            {
                message = $"Course with ID {id} was not found."
            });
        }

        course.CourseCode = updatedCourse.CourseCode;
        course.CourseName = updatedCourse.CourseName;
        course.Credits = updatedCourse.Credits;
        course.DepartmentId = updatedCourse.DepartmentId;

        await _context.SaveChangesAsync();

        return NoContent();
    }

    // DELETE: api/courses/1
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteCourse(int id)
    {
        var course = await _context.Courses.FindAsync(id);

        if (course is null)
        {
            return NotFound(new
            {
                message = $"Course with ID {id} was not found."
            });
        }

        _context.Courses.Remove(course);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
