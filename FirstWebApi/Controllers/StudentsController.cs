using FirstWebApi.Data;
using FirstWebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace FirstWebApi.Controllers
{
    [Route("api/students")]
    [Controller]
    public class StudentsController : ControllerBase
    {
        private readonly SchoolRepository _repo;

        public StudentsController()
        {
            _repo = new SchoolRepository();
        }

        [HttpGet]
        public ActionResult<IEnumerable<Student>> GetAllStudents()
        {
            return _repo.GetAllStudents();
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<Student> GetStudentById(int id)
        {
            
            var student = _repo.GetStudentById(id);
            if (_repo.GetStudentById(id) != null)
            {
                return Ok(_repo.GetStudentById(id));
            }
            return NotFound();
        }
    }
}
