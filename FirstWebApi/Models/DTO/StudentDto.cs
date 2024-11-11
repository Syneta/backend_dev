namespace FirstWebApi.Models.DTO
{
    public class StudentDto
    {
        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<CourseDto> Courses { get; set; }
    }
}
