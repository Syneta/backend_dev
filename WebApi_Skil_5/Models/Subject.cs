using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi_Skil_5.Models
{
    public class Subject
    {
        public int SubjectId { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string Title { get; set; } = null!;
        public List<Student> Students { get; set; }
        public List<Teacher> Teachers { get; set; }
    }
}
