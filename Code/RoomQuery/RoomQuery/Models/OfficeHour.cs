using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RoomQuery.Models
{
    public class OfficeHour
    {
        [Key]
        public int OfficeHourID { get; set; }
        public virtual Student Student { get; set; }
        public virtual Course Course { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
    }
}