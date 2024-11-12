using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi_Skil_5.Models
{
    public class Group
    {
        public int GroupId { get; set; }
        [Column(TypeName = "nvarchar(20)")]
        public string GroupName { get; set; } = null!;
        public List<Student> Students { get; set; } = new List<Student>();
    }
}
