using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Course_ASP_Project.Models
{
    public class StudentC
    {
        public int StudentID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public System.DateTime DateOfBirth { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string ImageName { get; set; }
        public string ImageUrl { get; set; }
        public int CourseID { get; set; }
        public int FacultyID { get; set; }
        public int TspID { get; set; }
        [NotMapped]
        public string CourseName { get; set; }
        [NotMapped]
        public string FacultyName { get; set; }
        [NotMapped]
        public string TspName { get; set; }
    }
}