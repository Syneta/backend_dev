using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_vika1.Models
{
    public class Username
    {
        public int UsernameID { get; set; }
        [MaxLength(20)]
        public string Name { get; set; }
        
        [MaxLength(50)]
        public string Password { get; set; }
    }
}
