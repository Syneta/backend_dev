using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_vika1.Models
{
    public class Blog
    {
        public int BlogID { get; set; }
        public string Url { get; set; }

        [NotMapped]
        public DateTime LoadedFromDb { get; set; } = DateTime.Now;

        public List<Post> Posts { get; set; } = new List<Post>();
    }
}
