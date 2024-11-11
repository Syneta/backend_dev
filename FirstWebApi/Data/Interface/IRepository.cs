using FirstWebApi.Models;
using FirstWebApi.Models.DTO;

namespace FirstWebApi.Data.Interface
{
    public interface IRepository
    {

        public interface IRepository
        {
            Task<List<StudentDto>> GetAllStudentsAsync();
            Task<StudentDto> GetStudentByIdAsync(int id);
            Task<List<CourseDto>> GetAllCoursesAsync();
            Task<CourseDto> GetCourseByIdAsync(int id);
            Task CreateStudentAsync(Student student);
            Task CreateCourseAsync(Course course);
            Task<Student> UpdateStudentAsync(int id, Student student);
            Task<Course> UpdateCourseAsync(int id, Course course);
            Task<bool> DeleteStudentAsync(int id);
            Task<bool> DeleteCourseAsync(int id);
        }



    }
}
