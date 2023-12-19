using System.ComponentModel.DataAnnotations;

namespace CoursesAppMVC.Models
{
     //The following method is adapted from:
     //Author: Microsoft
     //Link: https://learn.microsoft.com/en-us/aspnet/core/data/ef-mvc/intro?view=aspnetcore-6.0

    public class Modules
    {
       // Properties for model and database table

        [Key] 
        public int ModuleID { get; set; }
        [Display(Name = "Module Code")]
        public string? ModuleCode { get; set; }
        [Display(Name = "Module Name")]
        public string? ModuleName { get; set; }
        public int Credits { get; set; }
        [Display(Name = "Class Hours Each Week")]
        public int ClassHoursPerWeek { get; set; }
        [Display(Name = "Study Hours Remaining")]
        public double SelfStudyHoursPerWeek { get; set; }
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }
        [Display(Name = "Student")]
        public string? StudentID { get; set; }

        [Display(Name = "Semester Duration (Weeks)")]
        public int WeeksInSemester { get; set; }
        [Display(Name = "End of Semester")]
        public DateTime EndDate => StartDate.AddDays(7 * WeeksInSemester);

    }
}
