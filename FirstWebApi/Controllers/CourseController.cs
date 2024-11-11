using FirstWebApi.Data.Interface;
using FirstWebApi.Models;
using FirstWebApi.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace FirstWebApi.Controllers
{
    [Route("api/courses")]
    [Controller]
    public class CourseController : ControllerBase
    {
        private readonly IRepository _repository;

        public CourseController(IRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CourseDto>>> GetAllCourses()
        {
            try
            {
                var courses = await _repository.GetAllCoursesAsync();
                return Ok(courses);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<CourseDto>> GetCourseById(int id)
        {
            try
            {
                var course = await _repository.GetCourseByIdAsync(id);
                if (course != null)
                {
                    return Ok(course);
                }
                return NotFound();
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateCourse([FromBody] Course course)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _repository.CreateCourseAsync(course);
                    return CreatedAtAction(nameof(GetCourseById), new { id = course.CourseId }, course);
                }
                else
                {
                    return BadRequest(course);
                }
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateCourse(int id, [FromBody] Course course)
        {
            try
            {
                var updatedCourse = await _repository.UpdateCourseAsync(id, course);

                if (updatedCourse == null)
                {
                    return NotFound();
                }
                return CreatedAtAction(nameof(GetCourseById), new { id = course.CourseId }, course);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult<Course>> DeleteCourse(int id)
        {
            try
            {
                var deleteSuccess = await _repository.DeleteCourseAsync(id);

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
}
