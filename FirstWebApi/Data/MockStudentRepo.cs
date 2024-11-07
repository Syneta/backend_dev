using FirstWebApi.Models;

namespace FirstWebApi.Data
{
    public class MockStudentRepo : IRepository
    {
        List<Student> students = new List<Student>
            {
                new Student { StudentId = 1, FirstName = "John", LastName = "Doe", SSID = "123-45-6789" },
                new Student { StudentId = 2, FirstName = "Jane", LastName = "Smith", SSID = "987-65-4321" },
                new Student { StudentId = 3, FirstName = "Alice", LastName = "Wonderland", SSID = "456-78-9123" },
            };

        public List<Course> GetAllCourses()
        {
            throw new NotImplementedException();
        }

        public List<Student> GetAllStudents()
        {
            return students;
        }

        public Course GetCourseById(int id)
        {
            throw new NotImplementedException();
        }

        public Student GetStudentById(int id)
        {
            return students.FirstOrDefault(s => s.StudentId == id);
        }


    }
}
