using FirstWebApi.Data.Interface;
using FirstWebApi.Models;
using FirstWebApi.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace FirstWebApi.Controllers
{
    [Route("api/students")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IRepository _repository;

        public StudentsController(IRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        [HttpGet]
        public ActionResult<List<StudentDto>> GetAllStudents()
        {
            try
            {
                var students = _repository.GetAllStudents();
                return Ok(students);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<StudentDto> GetStudentById(int id)
        {
            try
            {
                var student = _repository.GetStudentById(id);
                if (student != null)
                {
                    var studentDto = new StudentDto
                    {
                        StudentId = student.StudentId,
                        FirstName = student.FirstName,
                        LastName = student.LastName,
                        Courses = student.Courses.Select(c => new CourseDto
                        {
                            CourseId = c.CourseId,
                            Name = c.Name
                        }).ToList()
                    };
                    return Ok(studentDto);
                }
                return NotFound();
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpPost]
        public IActionResult CreateStudent([FromBody] Student student)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _repository.CreateStudent(student);
                    var studentDto = new StudentDto
                    {
                        StudentId = student.StudentId,
                        FirstName = student.FirstName,
                        LastName = student.LastName,
                        Courses = student.Courses.Select(c => new CourseDto
                        {
                            CourseId = c.CourseId,
                            Name = c.Name
                        }).ToList()
                    };
                    return CreatedAtAction(nameof(GetStudentById), new { id = student.StudentId }, studentDto);
                }
                else
                {
                    return BadRequest(student);
                }
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpPut("{id}")]
        public ActionResult<StudentDto> UpdateStudent(int id, [FromBody] Student student)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var studentToUpdate = _repository.GetStudentById(id);
                    if (studentToUpdate == null)
                    {
                        return NotFound();
                    }
                    _repository.UpdateStudent(id, student);
                    var studentDto = new StudentDto
                    {
                        StudentId = student.StudentId,
                        FirstName = student.FirstName,
                        LastName = student.LastName,
                        Courses = student.Courses.Select(c => new CourseDto
                        {
                            CourseId = c.CourseId,
                            Name = c.Name
                        }).ToList()
                    };
                    return CreatedAtAction(nameof(GetStudentById), new { id = student.StudentId }, studentDto);
                }
                return BadRequest();
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteStudent(int id)
        {
            try
            {
                bool deleteSuccess = _repository.DeleteStudent(id);
                if (!deleteSuccess)
                {
                    return NotFound();
                }
                else
                {
                    return NoContent();
                }
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
    }
}
