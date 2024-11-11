using FirstWebApi.Data.Interface;
using FirstWebApi.Models;
using FirstWebApi.Models.DTO;

namespace FirstWebApi.Data.Repository
{
    public class MockRepo : IRepository
    {
        List<Student> students = new List<Student>
            {
                new Student { StudentId = 1, FirstName = "John", LastName = "Doe", SSID = "123-45-6789" },
                new Student { StudentId = 2, FirstName = "Jane", LastName = "Smith", SSID = "987-65-4321" },
                new Student { StudentId = 3, FirstName = "Alice", LastName = "Wonderland", SSID = "456-78-9123" },
            };

        List<Course> courses = new List<Course>
                {
                    new Course { CourseId = 1, Name = "Stræðfræði" },
                    new Course { CourseId = 2, Name = "Forritun" },
                    new Course { CourseId = 3, Name = "Saga" },
                };

        public void CreateCourse(Course course)
        {
            throw new NotImplementedException();
        }

        public void CreateStudent(Student student)
        {
            throw new NotImplementedException();
        }

        public bool DeleteCourse(int id)
        {
            throw new NotImplementedException();
        }

        public bool DeleteStudent(int id)
        {
            throw new NotImplementedException();
        }

        public List<Course> GetAllCourses()
        {
            throw new NotImplementedException();
        }

        public List<StudentDto> GetAllStudents()
        {
            throw new NotImplementedException();
        }

        public Course GetCourseById(int id)
        {
            throw new NotImplementedException();
        }

        public Student GetStudentById(int id)
        {
            throw new NotImplementedException();
        }

        public Course UpdateCourse(int id, Course course)
        {
            throw new NotImplementedException();
        }

        public Student UpdateStudent(int id, Student student)
        {
            throw new NotImplementedException();
        }

        List<CourseDto> IRepository.GetAllCourses()
        {
            throw new NotImplementedException();
        }

        CourseDto IRepository.GetCourseById(int id)
        {
            throw new NotImplementedException();
        }

        StudentDto IRepository.GetStudentById(int id)
        {
            throw new NotImplementedException();
        }
    }
}

        