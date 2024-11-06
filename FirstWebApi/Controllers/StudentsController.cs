using FirstWebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace FirstWebApi.Controllers
{
    [Route("api/students")]
    [Controller]
    public class StudentsController : ControllerBase
    {
        [HttpGet]
        public List<Student> AllStudents()
        {
            return new List<Student>             {
                new Student { StudentId = 1, FirstName = "John", LastName = "Doe", SSID = "123-45-6789" },
                new Student { StudentId = 2, FirstName = "Jane", LastName = "Smith", SSID = "987-65-4321" }
            };
        }
        [HttpGet]
        [Route("{id}")]
        public Student GetStudentById(int id)
        {
            List<Student> s = new List<Student>
            {
                new Student { StudentId = 1, FirstName = "John", LastName = "Doe", SSID = "123-45-6789" },
                new Student { StudentId = 2, FirstName = "Jane", LastName = "Smith", SSID = "987-65-4321" },
                new Student { StudentId = 3, FirstName = "Alice", LastName = "Wonderland", SSID = "456-78-9123" },
            };

            return s.FirstOrDefault(s => s.StudentId == id);
        }
    }
}
