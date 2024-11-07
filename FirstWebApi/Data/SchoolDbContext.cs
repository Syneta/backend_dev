using FirstWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace FirstWebApi.Data
{
    public class SchoolDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; } = null!;
        public DbSet<Course> Courses { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=SchoolDb;Trusted_Connection=True;");
        }
    }
}
