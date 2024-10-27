using EF_vika1.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_vika1.Data
{
    public class BloggingContext: DbContext
    {
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Username> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AuditEntry>();
        }

        public static void SeedDatabase()
        {
            using (var db = new BloggingContext())
            {
                db.Database.EnsureCreated();

                
                var b1Exists = db.Blogs.FirstOrDefault(x => x.Url == "https://www.visir.is");
                if (b1Exists == null)
                {
                    Blog b1 = new Blog { Url = "https://www.visir.is" };
                    Post p1 = new Post { Title = "Bíll til sölu", Content = "Bíllinn er í góðu standi", Blog = b1 };
                    db.Add(b1);
                    b1.Posts.Add(p1);
                }

                var b2Exists = db.Blogs.FirstOrDefault(x => x.Url == "https://www.mbl.is");
                if(b2Exists == null)
                {
                    Blog b2 = new Blog { Url = "https://www.mbl.is" };
                    db.Add(b2);
                    Post p2 = new Post { Title = "Skip til sölu", Content = "Skipið er í góðu standi" };
                    b2.Posts.Add(p2);

                }

                var b3Exists = db.Blogs.FirstOrDefault(x => x.Url == "https://www.mbl.is");
                if (b3Exists == null)
                {
                    Blog b3 = new Blog { Url = "https://www.ruv.is" };
                    db.Add(b3);

                }

                var u1Exists = db.Users.FirstOrDefault(x => x.Name == "admin");
                if(u1Exists == null)
                {
                    Username u1 = new Username { Name = "admin", Password = "admin" };
                    db.Add(u1);
                }
                
                var u2Exists = db.Users.FirstOrDefault(x => x.Name == "user");
                if (u2Exists == null)
                {
                    Username u2 = new Username { Name = "user", Password = "user" };
                    db.Add(u2);
                }

                db.SaveChanges();
            }
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Bloggindb;");
        }
    }
}