namespace FirstWebApi.Models.DTO
{
    public class CourseDto
    {
        public int CourseId { get; set; }
        public string Name { get; set; }
        public List<StudentDto> Students { get; set; } // Add this line to fix the error
    }
}
