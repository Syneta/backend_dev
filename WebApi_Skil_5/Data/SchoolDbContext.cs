using ErdToDatabase.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi_Skil_5.Models;

namespace WebApi_Skil_5.Data
{
    public class SchoolDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; } = null!;
        public DbSet<Group> Groups { get; set; } = null!;
        public DbSet<Subject> Subjects { get; set; } = null!;
        public DbSet<Teacher> Teachers { get; set; } = null!;
        public DbSet<Mark> Marks { get; set; } = null!;

        /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=WebApi_Schooldb;ConnectRetryCount=0");
        }*/
        public SchoolDbContext(DbContextOptions<SchoolDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Group>().HasData(
                new Group { GroupId = 1, GroupName = "Group A" },
                new Group { GroupId = 2, GroupName = "Group B" }
            );

            modelBuilder.Entity<Subject>().HasData(
                new Subject { SubjectId = 1, Title = "Math" },
                new Subject { SubjectId = 2, Title = "Science" }
            );

            modelBuilder.Entity<Teacher>().HasData(
                new Teacher { TeacherId = 1, TeacherFirstName = "John", TeacherLastName = "Doe" },
                new Teacher { TeacherId = 2, TeacherFirstName = "Jane", TeacherLastName = "Smith" }
            );

            modelBuilder.Entity<Student>().HasData(
                new Student { StudentId = 1, StudentFirstName = "Alice", StudentLastName = "Johnson", GroupId = 1 },
                new Student { StudentId = 2, StudentFirstName = "Bob", StudentLastName = "Brown", GroupId = 2 }
            );

            modelBuilder.Entity<Mark>().HasData(
                new Mark { MarkId = 1, StudentId = 1, SubjectId = 1, Date = DateTime.Now, MarkNum = 90 },
                new Mark { MarkId = 2, StudentId = 2, SubjectId = 2, Date = DateTime.Now, MarkNum = 85 }
            );

            // Seed data for SubjectTeacher (many-to-many relationship)
            modelBuilder.Entity<Subject>()
                .HasMany(s => s.Teachers)
                .WithMany(t => t.Subjects)
                .UsingEntity<Dictionary<string, object>>(
                    "SubjectTeacher",
                    j => j.HasData(
                        new { SubjectsSubjectId = 1, TeachersTeacherId = 1 },
                        new { SubjectsSubjectId = 2, TeachersTeacherId = 2 }
                    )
                );
        }
    }
}

