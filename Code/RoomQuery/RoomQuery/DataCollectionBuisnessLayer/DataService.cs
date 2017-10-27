using RoomQuery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RoomQuery.DataCollectionBuisnessLayer
{
    public class DataService
    {
        private ApplicationDbContext Context = ApplicationDbContext.Create();

        public IEnumerable<Student> GetStudents()
        {
            return Context.Students.Where(x => x != null);
        }

        public IEnumerable<Student> GetCurrentStudents()
        {
            return this.GetStudents().Where(x => x.InSRC == true);
        }

        public void HandleScan(String n)
        {
            var student = this.GetStudents().FirstOrDefault(x => x.Nuid == n);
            student.InSRC = !student.InSRC;
            this.GetStudents().FirstOrDefault(x => x.StudentID == student.StudentID).InSRC = student.InSRC;

            this.Context.SaveChanges();

            SRCTimestamp newStamp = new SRCTimestamp();
            newStamp.Stamp = DateTime.Now;
            newStamp.Student = student;
            newStamp.WasCheckIn = student.InSRC;
            this.Context.Timestamps.Add(newStamp);

            this.Context.SaveChanges();
        }
    }
}