using System.ComponentModel.DataAnnotations;

namespace FirstWebApi.Models
{
    public class Course
    {
        public int CourseId { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = null!;
        public List<Student> Students { get; set; } = new List<Student>();
    }
}
