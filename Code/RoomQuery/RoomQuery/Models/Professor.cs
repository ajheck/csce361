using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RoomQuery.Models
{
    public class Professor
    {
        [Key]
        public int ProfessorID { get; set; }
        [Column(TypeName = "VARCHAR")]
        [StringLength(16)]
        public string Nuid { get; set; }
        public UInt64 PassHash { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}