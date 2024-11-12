using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi_Skil_5.Models
{
    public class Teacher
    {
        public int TeacherId { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string TeacherFirstName { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string TeacherLastName { get; set; }
        public List<Subject> Subjects { get; set; } = new List<Subject>();
    }
}
