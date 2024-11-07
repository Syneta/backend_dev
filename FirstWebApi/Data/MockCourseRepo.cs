using FirstWebApi.Models;

namespace FirstWebApi.Data
{
    public class MockCourseRepo : IRepository
    {
        private List<Course> courses;

        public MockCourseRepo()
        {
            courses = new List<Course>
                {
                    new Course { CourseId = 1, Name = "Stræðfræði" },
                    new Course { CourseId = 2, Name = "Forritun" },
                    new Course { CourseId = 3, Name = "Saga" },
                };
        }

        public List<Course> GetAllCourses()
        {
            return courses;
        }

        public List<Student> GetAllStudents()
        {
            throw new NotImplementedException();
        }

        public Course GetCourseById(int id)
        {
            return courses.FirstOrDefault(c => c.CourseId == id);
        }

        public Student GetStudentById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
