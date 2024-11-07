using FirstWebApi.Models;

namespace FirstWebApi.Data
{
    public interface IRepository
    {

        List<Student> GetAllStudents();
        Student GetStudentById(int id);

        List<Course> GetAllCourses();
        Course GetCourseById(int id);


    }
}
