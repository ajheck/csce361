using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RoomQuery.Models
{
    public class SRCTimestamp
    {
        [Key]
        public int TimeStampID { get; set; }
        public virtual Student Student { get; set; }
        public virtual bool WasCheckIn { get; set; }
        public DateTime Stamp { get; }
    }
}