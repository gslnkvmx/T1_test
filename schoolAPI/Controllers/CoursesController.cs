using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using schoolAPI.Data;
using schoolAPI.Models;

namespace schoolAPI.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class CoursesController : ControllerBase
  {
    private readonly SchoolContext _context;
    public CoursesController(SchoolContext context)
    {
      _context = context;
    }

    // GET /courses
    [HttpGet]
    [Route("/courses")]
    public async Task<IActionResult> GetCourses()
    {
      var courses = await _context.Courses
          .Include(c => c.Students)
          .Select(c => new
          {
            id = c.Id,
            name = c.Name,
            students = c.Students.Select(s => new { id = s.Id, fullName = s.FullName })
          })
          .ToListAsync();
      return Ok(courses);
    }

    // POST /courses
    [HttpPost]
    [Route("/courses")]
    public async Task<IActionResult> CreateCourse([FromBody] CourseCreateDto dto)
    {
      var course = new Course { Id = Guid.NewGuid(), Name = dto.Name };
      _context.Courses.Add(course);
      await _context.SaveChangesAsync();
      return Ok(new { id = course.Id });
    }

    // POST /courses/{id:guid}/students
    [HttpPost]
    [Route("/courses/{id:guid}/students")]
    public async Task<IActionResult> AddStudent(Guid id, [FromBody] StudentCreateDto dto)
    {
      var course = await _context.Courses.FindAsync(id);
      if (course == null) return NotFound();
      var student = new Student { Id = Guid.NewGuid(), FullName = dto.FullName, CourseId = id };
      _context.Students.Add(student);
      await _context.SaveChangesAsync();
      return Ok(new { id = student.Id });
    }

    // DELETE /courses/{id:guid}
    [HttpDelete]
    [Route("/courses/{id:guid}")]
    public async Task<IActionResult> DeleteCourse(Guid id)
    {
      var course = await _context.Courses.Include(c => c.Students).FirstOrDefaultAsync(c => c.Id == id);
      if (course == null) return NotFound();
      _context.Students.RemoveRange(course.Students);
      _context.Courses.Remove(course);
      await _context.SaveChangesAsync();
      return NoContent();
    }
  }

  public record CourseCreateDto
  {
    public required string Name { get; set; }
  }
  public record StudentCreateDto
  {
    public required string FullName { get; set; }
  }
}