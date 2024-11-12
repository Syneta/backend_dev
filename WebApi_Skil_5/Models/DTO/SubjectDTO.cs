using System.Collections.Generic;

namespace ErdToDatabase.Models.DTOs
{
    public class SubjectDTO
    {
        public int SubjectId { get; set; }
        public string Title { get; set; } = null!;
        public List<StudentDTO> Students { get; set; } = new List<StudentDTO>();
        public List<TeacherDTO> Teachers { get; set; } = new List<TeacherDTO>();
    }
}
