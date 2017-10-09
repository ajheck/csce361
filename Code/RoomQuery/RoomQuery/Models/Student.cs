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
        int StudentID { get; set; }
        [Index(IsUnique = true)]
        int Nuid { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        bool InSRC { get; set; }
    }
}