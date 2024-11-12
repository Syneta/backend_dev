using System.Collections.Generic;

namespace ErdToDatabase.Models.DTOs
{
    public class GroupDTO
    {
        public int GroupId { get; set; }
        public string GroupName { get; set; } = null!;
        public List<StudentDTO> Students { get; set; } = new List<StudentDTO>();
    }
}
