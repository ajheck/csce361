using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RoomQuery.Models
{
    public class Course
    {
        [Key]
        public int CourseID { get; }
        public virtual ICollection<Student> Roster { get; set; }
        public string CourseNumber { get; set; }
        public string CourseName { get; set; }
    }
}