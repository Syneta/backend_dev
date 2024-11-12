using System.Collections.Generic;

namespace ErdToDatabase.Models.DTOs
{
    public class TeacherDTO
    {
        public int TeacherId { get; set; }
        public string TeacherFirstName { get; set; } = null!;
        public string TeacherLastName { get; set; } = null!;
        public List<SubjectDTO> Subjects { get; set; } = new List<SubjectDTO>();
    }
}
