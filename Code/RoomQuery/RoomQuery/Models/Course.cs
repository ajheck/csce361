using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RoomQuery.Models
{
    public class Course
    {
        [Key]
        public int CourseID { get; }
        public virtual ICollection<Student> Roster { get; set; }
        [Index(IsUnique = true)]
        public string CourseNumber { get; set; }
        [Index(IsUnique = true)]
        public string CourseName { get; set; }
    }
}