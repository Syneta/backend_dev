﻿namespace FirstWebApi.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string SSID { get; set; }
        public List<Course> Courses { get; set; }

    }
}
