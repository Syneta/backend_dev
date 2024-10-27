// See https://aka.ms/new-console-template for more information
using EF_vika1.Data;
using EF_vika1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.Json;
using System;

namespace EF_vika1
{
    class Program
    {
        static void Main(string[] args)
        {

            BloggingContext.SeedDatabase();
           


            Username loggedInUser = null;

            using (var db = new BloggingContext())
            {

                while (loggedInUser == null)
                {
                    Console.Write("Enter username: ");
                    string Username = Console.ReadLine();
                    Console.Write("Enter password: ");
                    string Password = Console.ReadLine();

                    loggedInUser = db.Users.FromSqlInterpolated($"SELECT * FROM Users WHERE Name = '{Username}' AND Password = '{Password}'").FirstOrDefault();

                    if (loggedInUser == null)
                    {
                        Console.WriteLine("No user found, incorrect username or password");
                        
                    }
                    else
                    {
                        Console.WriteLine($"Logged in user: {loggedInUser.Name}");
                    }
                }
            }

            /*
            //Create 2 posts

            using (var db = new BloggingContext())
            {
                Blog b = new Blog();
                b.Url = "https://www.blogger.com";

                b.Posts.Add(new Post
                {
                    Title = "The rise of the patriarchy",
                    Content = "Feminism is killing love and happy sex life"
                });

                b.Posts.Add(new Post
                {
                    Title = "I'm a misogyny girl",
                    Content = "Fuck feminism, girls are stupid inferior cunts, and need male dominance"
                });

                db.Blogs.Add(b);
                db.SaveChanges();
            }
            

            Post p1;

            using (var db = new BloggingContext())
            {
                p1 = db.Posts.Include(x => x.Blog).FirstOrDefault();
            }
            Console.WriteLine(p1.Blog.Url);

                
    using (var db = new BloggingContext())
    {
        Blog b = new Blog {Url = "https://www.blogspot.is" };
        db.Blogs.Add(b);
        db.SaveChanges();
    }
    */

            //Read
            /*
            using (var db = new BloggingContext())
            {
                Console.WriteLine("One blog in the database:");
                var blog = db.Blogs.Where(b => b.BlogID == 3).Single();
                Console.WriteLine(blog.Url);
            }

            //Update and add post
            using (var db = new BloggingContext())
            {
                Console.WriteLine("Updating one blog");
                var blog = db.Blogs.Where(b => b.BlogID == 3).FirstOrDefault();
                blog.Url = "https://www.motherless.com";

                Post p = new Post { Title = "Rise of the patriarchy", Content = "Feminism is killing love and pleasure for BOTH men and women, be happy and stop feminism \n P.s. Show your titties" };

                blog.Posts.Add(p);
                db.SaveChanges();

                Console.WriteLine(p.Title);
                Console.WriteLine(p.Content);
            }

            using (var db = new BloggingContext())
            {
                Console.WriteLine("One blog in the database:");
                var blog = db.Blogs.Where(b => b.BlogID == 3).Single();
                Console.WriteLine(blog.Url);
            }



            using (var db = new BloggingContext())
            {
                Console.WriteLine("Delete one blog with BlogId");
                var blog = db.Blogs.Where(b => b.BlogID == 2).FirstOrDefault();
                if(blog != null)
                {
                db.Remove(blog);
                db.SaveChanges();
                    Console.WriteLine("Blog deleted");
                }
                else
                {
                    Console.WriteLine("No blog found");
                }
            }


            //show whole database
            using(var db = new BloggingContext()) {
                Console.WriteLine("Printing the whole db");
                var blogs = db.Blogs.ToList();
                var posts = db.Posts.ToList();
                foreach (Blog blog in blogs)
                {
                    Console.WriteLine($"BlogID: {blog.BlogID}, Url: {blog.Url}");
                    foreach (Post post in posts)
                    {
                        if (post.BlogId == blog.BlogID)
                        {
                            Console.WriteLine($"ID: {post.Id}, Title: {post.Title}, Content: {post.Content}");
                        }
                    }
                }
            }
            */
        }
    }
}
