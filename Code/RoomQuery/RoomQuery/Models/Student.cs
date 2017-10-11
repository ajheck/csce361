using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RoomQuery.Models
{
    public class Student
    {
        [Key]
        public int StudentID { get; set; }
        [Column(TypeName = "VARCHAR")]
        [StringLength(16)]
        [Index(IsUnique = true)]
        [NotMapped]
        public string Nuid { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool InSRC { get; set; }
        public bool IsTA { get; set; }
     }

}