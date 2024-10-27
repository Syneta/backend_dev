using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErdToDatabase.Models
{
    public class Mark
    {
        public int MarkId { get; set; }
        public int StudentId { get; set; } 
        public int SubjectId { get; set; }
        public DateTime Date { get; set; }
        [Required]
        public int MarkNum { get; set; }
    }
}
