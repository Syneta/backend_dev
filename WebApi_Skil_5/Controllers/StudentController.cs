using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi_Skil_5.Data;
using WebApi_Skil_5.Models;

namespace WebApi_Skil_5.Controllers
{
    [Route("api/students")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly SchoolDbContext _context;

        public StudentController(SchoolDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Student>>> GetStudents()
        {
            try
            {
            return await _context.Students.ToListAsync();

            }
            catch (Exception)
            {

                return StatusCode(500);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> GetStudent(int id)
        {
            try
            {
                var student = await _context.Students.FindAsync(id);

                if (student == null)
                {
                    return NotFound();
                }

                return student;

            }
            catch (Exception)
            {

                return StatusCode(500);
            }
        }
        [HttpPost]
        public async Task<ActionResult<Student>> PostStudent ([FromBody] Student student)
        {
            try
            {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _context.Students.Add(student);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetStudent), new { id = student.StudentId }, student);

            }
            catch (Exception)
            {

                return StatusCode(500);
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudent( int id, [FromBody] Student student)
        {
            try
            {
                if (id != student.StudentId)
                {
                    return BadRequest();
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                _context.Entry(student).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception)
            {

                return StatusCode(500);
            }
            
        }

        [HttpDelete("{id}")]

        public async Task<IActionResult> DeleteStudent(int id)
        {
            try
            {
            var student = await _context.Students.FindAsync(id);

            if (student == null)
            {
                return NotFound();
            }

            _context.Students.Remove(student);
            await _context.SaveChangesAsync();

            return NoContent();

            }
            catch (Exception)
            {

                return StatusCode(500);
            }

        }
            private bool StudentExists(int id)
            {
                return _context.Students.Any(e => e.StudentId == id);
            }
    }
}
