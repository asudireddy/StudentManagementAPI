using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentMangementAPI.Data;
using StudentMangementAPI.Models;

namespace StudentMangementAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DepartmentsController : ControllerBase
{
    private readonly StudentDbContext _context;

    public DepartmentsController(StudentDbContext context)
    {
        _context = context;
    }

    // GET: api/departments
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Department>>> GetDepartments()
    {
        var departments = await _context.Departments.ToListAsync();

        return Ok(departments);
    }

    // GET: api/departments/1
    [HttpGet("{id:int}")]
    public async Task<ActionResult<Department>> GetDepartment(int id)
    {
        var department = await _context.Departments.FindAsync(id);

        if (department is null)
        {
            return NotFound(new
            {
                message = $"Department with ID {id} was not found."
            });
        }

        return Ok(department);
    }

    // POST: api/departments
    [HttpPost]
    public async Task<ActionResult<Department>> CreateDepartment(
        Department department)
    {
        _context.Departments.Add(department);

        await _context.SaveChangesAsync();

        return CreatedAtAction(
            nameof(GetDepartment),
            new { id = department.Id },
            department);
    }

    // PUT: api/departments/1
    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateDepartment(
        int id,
        Department updatedDepartment)
    {
        var department = await _context.Departments.FindAsync(id);

        if (department is null)
        {
            return NotFound(new
            {
                message = $"Department with ID {id} was not found."
            });
        }

        department.DepartmentName = updatedDepartment.DepartmentName;

        await _context.SaveChangesAsync();

        return NoContent();
    }

    // DELETE: api/departments/1
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteDepartment(int id)
    {
        var department = await _context.Departments.FindAsync(id);

        if (department is null)
        {
            return NotFound(new
            {
                message = $"Department with ID {id} was not found."
            });
        }

        _context.Departments.Remove(department);

        await _context.SaveChangesAsync();

        return NoContent();
    }
}