using System.Collections.Generic;

namespace ErdToDatabase.Models.DTOs
{
    public class StudentDTO
    {
        public int StudentId { get; set; }
        public string StudentFirstName { get; set; } = null!;
        public string StudentLastName { get; set; } = null!;
        public int GroupId { get; set; }
        public List<MarkDTO> Marks { get; set; } = new List<MarkDTO>();
    }
}
