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
        public int CourseID { get; set; }
        public virtual ICollection<Student> Roster { get; set; }
        [Column(TypeName = "VARCHAR")]
        [StringLength(32)]
        [Index(IsUnique = true)]
        public string CourseNumber { get; set; }
        [Column(TypeName = "VARCHAR")]
        [StringLength(128)]
        public string CourseName { get; set; }
        public virtual Professor Professor { get; set; }
    }
}