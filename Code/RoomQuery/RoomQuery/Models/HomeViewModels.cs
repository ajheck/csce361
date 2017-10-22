using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RoomQuery.Models
{
    public class IndexViewModel
    {
        public int Population { get; set; }
        public IEnumerable<OfficeHour> CurrentOfficeHours { get; set; }
        public IEnumerable<OfficeHour> WeeklyOfficeHours { get; set; }
    }
}