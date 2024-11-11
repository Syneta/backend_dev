using FirstWebApi.Data.Interface;
using FirstWebApi.Models;
using FirstWebApi.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FirstWebApi.Data.Repository
{
    public class SchoolRepository : IRepository
    {
        private readonly SchoolDbContext _dbContext;

        public SchoolRepository()
        {
            _dbContext = new SchoolDbContext();
        }

        public async Task CreateCourseAsync(Course course)
        {
            await using (var db = _dbContext)
            {
                await db.Courses.AddAsync(course);
                await db.SaveChangesAsync();
            }
        }

        public async Task CreateStudentAsync(Student student)
        {
            await using (var db = _dbContext)
            {
                await db.Students.AddAsync(student);
                await db.SaveChangesAsync();
            }
        }

        public async Task<bool> DeleteCourseAsync(int id)
        {
            Course courseToDelete;

            await using (var db = _dbContext)
            {
                courseToDelete = await db.Courses.FirstOrDefaultAsync(c => c.CourseId == id);
                if (courseToDelete == null)
                {
                    return false;
                }
                db.Courses.Remove(courseToDelete);
                await db.SaveChangesAsync();
                return true;
            }
        }

        public async Task<bool> DeleteStudentAsync(int id)
        {
            Student studentToDelete;

            await using (var db = _dbContext)
            {
                studentToDelete = await db.Students.FirstOrDefaultAsync(s => s.StudentId == id);
                if (studentToDelete == null)
                {
                    return false;
                }
                db.Students.Remove(studentToDelete);
                await db.SaveChangesAsync();
                return true;
            }
        }

        public async Task<List<CourseDto>> GetAllCoursesAsync()
        {
            List<Course> courses;
            await using (var db = _dbContext)
            {
                courses = await db.Courses.Include(c => c.Students).ToListAsync();
            }
            List<CourseDto> returnList = new List<CourseDto>();

            foreach (Course course in courses)
            {
                returnList.Add(new CourseDto
                {
                    CourseId = course.CourseId,
                    Name = course.Name,
                    Students = course.Students.Select(s => new StudentDto
                    {
                        StudentId = s.StudentId,
                        FirstName = s.FirstName,
                        LastName = s.LastName
                    }).ToList()
                });
            }
            return returnList;
        }

        public async Task<List<StudentDto>> GetAllStudentsAsync()
        {
            List<Student> students;
            await using (var db = _dbContext)
            {
                students = await db.Students.Include(s => s.Courses).ToListAsync();
            }
            List<StudentDto> returnList = new List<StudentDto>();

            foreach (Student student in students)
            {
                StudentDto studentDto = new StudentDto
                {
                    StudentId = student.StudentId,
                    FirstName = student.FirstName,
                    LastName = student.LastName,
                    Courses = student.Courses.Select(c => new CourseDto
                    {
                        CourseId = c.CourseId,
                        Name = c.Name
                    }).ToList()
                };
                returnList.Add(studentDto);
            }

            return returnList;
        }

        public async Task<CourseDto> GetCourseByIdAsync(int id)
        {
            await using (var db = _dbContext)
            {
                var course = await db.Courses.Include(c => c.Students).FirstOrDefaultAsync(c => c.CourseId == id);
                if (course == null)
                {
                    return null;
                }
                return new CourseDto
                {
                    CourseId = course.CourseId,
                    Name = course.Name,
                    Students = course.Students.Select(s => new StudentDto
                    {
                        StudentId = s.StudentId,
                        FirstName = s.FirstName,
                        LastName = s.LastName
                    }).ToList()
                };
            }
        }

        public async Task<StudentDto> GetStudentByIdAsync(int id)
        {
            await using (_dbContext)
            {
                var student = await _dbContext.Students.Include(s => s.Courses).FirstOrDefaultAsync(s => s.StudentId == id);
                if (student == null)
                {
                    return null;
                }
                return new StudentDto
                {
                    StudentId = student.StudentId,
                    FirstName = student.FirstName,
                    LastName = student.LastName,
                    Courses = student.Courses.Select(c => new CourseDto
                    {
                        CourseId = c.CourseId,
                        Name = c.Name
                    }).ToList()
                };
            }
        }

        public async Task<Course> UpdateCourseAsync(int id, Course course)
        {
            Course courseToUpdate;

            await using (var db = _dbContext)
            {
                courseToUpdate = await db.Courses.FirstOrDefaultAsync(c => c.CourseId == id);
                if (courseToUpdate == null)
                {
                    return null;
                }
                courseToUpdate.Name = course.Name;
                await db.SaveChangesAsync();
            }
            return courseToUpdate;
        }

        public async Task<Student> UpdateStudentAsync(int id, Student student)
        {
            Student studentToUpdate;

            await using (var db = _dbContext)
            {
                studentToUpdate = await db.Students.FirstOrDefaultAsync(s => s.StudentId == id);
                if (studentToUpdate == null)
                {
                    return null;
                }
                studentToUpdate.FirstName = student.FirstName;
                studentToUpdate.LastName = student.LastName;
                studentToUpdate.SSID = student.SSID;
                await db.SaveChangesAsync();
            }
            return studentToUpdate;
        }
    }
}
