using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RoomQuery.Models
{
    public class IndexProfessorViewModel
    {

    }

    public class HoursChartViewModel
    {
        public int ClassHours { get; set; }
        public string GraphLabel { get; set; }
    }

    public class StudentChartViewModel
    {
        public int StudentHours { get; set; }
        public string GraphLabel { get; set; }
    }

    public class NumStudentChartViewModel
    {
        public int NumStudents { get; set; }
        public string GraphLabel { get; set; }
    }
}