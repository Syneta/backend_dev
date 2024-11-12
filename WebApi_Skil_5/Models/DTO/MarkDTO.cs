using System;

namespace ErdToDatabase.Models.DTOs
{
    public class MarkDTO
    {
        public int MarkId { get; set; }
        public int StudentId { get; set; }
        public int SubjectId { get; set; }
        public DateTime Date { get; set; }
        public int MarkNum { get; set; }
    }
}
