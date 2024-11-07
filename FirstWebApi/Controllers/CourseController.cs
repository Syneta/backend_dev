using FirstWebApi.Data;
using FirstWebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace FirstWebApi.Controllers
{
    [Route("api/courses")]
    [Controller]
    public class CourseController : ControllerBase
    {
        private readonly SchoolRepository _repo;

        public CourseController()
        {
            _repo = new SchoolRepository();
        }

        [HttpGet]
        public ActionResult<IEnumerable<Course>> GetAllCourses()
        {
            return Ok(_repo.GetAllCourses());
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<Course> GetCourseById(int id)
        {
            var course = _repo.GetCourseById(id);
            if (course != null)
            {
                return Ok(course);
            }
            return NotFound();
        }
    }
}
