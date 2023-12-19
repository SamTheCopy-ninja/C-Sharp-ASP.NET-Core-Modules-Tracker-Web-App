using System.ComponentModel.DataAnnotations;

namespace CoursesAppMVC.Models
{
    //The following method is adapted from:
    //Author: Microsoft
    //Link: https://learn.microsoft.com/en-us/aspnet/core/data/ef-mvc/intro?view=aspnetcore-6.0
    public class Student
    {
        // Properties for model and database table
        public int StudentID { get; set; }
        [Display(Name = "Student Name")]
        public string? FirstName { get; set; }
        [Display(Name = "Student Surname")]
        public string? LastName { get; set; }
        [Display(Name = "Username")]
        public string? Username { get; set; }
        [Display(Name = "Hashed Password")]
        public string? PasswordHash { get; set; }
    }
}
