using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace RoomQuery.Models
{
    public class IndexViewModel
    {
        [DisplayName("Population")]
        public int Population { get; set; }

        [DisplayName("ActiveOfficeHours")]
        public List<OfficeHour> ActiveOfficeHours { get; set; }

        [DisplayName("WeeklyOfficeHours")]
        public List<OfficeHour> WeeklyOfficeHours { get; set; }
    }

    public class HomeViewModel
    {
        public int RoomPopulation { get; set; }
    }
}