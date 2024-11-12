using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi_Skil_5.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string StudentFirstName { get; set; } = null!;
        [Column(TypeName = "nvarchar(50)")]
        public string StudentLastName { get; set; } = null!;
        public int GroupId { get; set; }
        public List<Mark> Mark { get; set; } = new List<Mark>();
    }
}
