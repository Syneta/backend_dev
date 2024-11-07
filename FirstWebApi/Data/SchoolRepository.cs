using FirstWebApi.Models;

namespace FirstWebApi.Data
{
    public class SchoolRepository : IRepository
    {
        private readonly SchoolDbContext _dbContext;

        public SchoolRepository()
        {
            _dbContext = new SchoolDbContext(); 
        }

        public List<Course> GetAllCourses()
        {
            using(_dbContext)
            {
                return _dbContext.Courses.ToList();
            }
        }

        public List<Student> GetAllStudents()
        {
            using(_dbContext)
            {
                return _dbContext.Students.ToList();
            }
        }

        public Course GetCourseById(int id)
        {
            using(_dbContext)
            {
                return _dbContext.Courses.FirstOrDefault(c => c.CourseId == id);
            }
        }

        public Student GetStudentById(int id)
        {
            using(_dbContext)
            {
                return _dbContext.Students.FirstOrDefault(s => s.StudentId == id);
            }
        }
    }
}
