// See https://aka.ms/new-console-template for more information

using ErdToDatabase.Data;
using ErdToDatabase.Models;

namespace ErdToDatabase
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new SchoolDbContext())
            {
                var student = new Student()
                {
                    StudentFirstName = "John",
                    StudentLastName = "Doe",
                    GroupId = 1
                };
                db.Add(student);

                var Group = new Group()
                {
                    GroupName = "Best Group"
                };
                db.Add(Group);

                var subject = new Subject()
                {
                    Title = "Math",
            
                };
                db.Add(subject);

                var teacher = new Teacher()
                {
                    TeacherFirstName = "Jane",
                    TeacherLastName = "Doe",
                    Subjects = subject{ Title = "Math" }
                };
                db.Add(teacher);

                var mark = new Mark()
                {
                    MarkNum = 5,
                    StudentId = 1,
                    SubjectId = 1
                };

                db.Add(mark);

                db.SaveChanges();
            }
        }
    }
}
