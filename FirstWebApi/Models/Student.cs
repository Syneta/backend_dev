using System.ComponentModel.DataAnnotations;

namespace FirstWebApi.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [MaxLength(50)]
        public string SSID { get; set; }
        public List<Course> Courses { get; set; } = new List<Course>();

    }
}
