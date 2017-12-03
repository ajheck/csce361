using RoomQuery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RoomQuery.WebAppBuisnessLayer
{
    public class AdministratorService
    {
        private ApplicationDbContext Context = ApplicationDbContext.Create();

        public IEnumerable<Student> GetStudents()
        {
            return Context.Students.Where(x => x != null);
        }

        public IEnumerable<Course> GetCourses()
        {
            return Context.Courses.Where(x => x != null);
        }

        public void ModifyTAStatus(String n)
        {
            var student = this.GetStudents().FirstOrDefault(x => x.Nuid == n);

            if (student != null)
            {
                student.IsTA = !student.IsTA;
                this.GetStudents().FirstOrDefault(x => x.StudentID == student.StudentID).IsTA = student.IsTA;

                this.Context.SaveChanges();
            }
        }

        public void AddTA(string nuid, string dayOfWeek, int hourStart, int minStart, int hourEnd, int minEnd, string courseNum)
        {
            var s = this.GetStudents().FirstOrDefault(x => x.Nuid == nuid);
            var c = this.GetCourses().Where(x => x.CourseNumber == courseNum).FirstOrDefault();

            if (s != null && c != null)
            {
                if (dayOfWeek.Equals("Monday"))
                {
                    OfficeHour newOfficeHour = new OfficeHour();
                    newOfficeHour.Course = c;
                    newOfficeHour.Student = s;
                    newOfficeHour.Start = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 4, hourStart, minStart, 0);
                    newOfficeHour.End = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 4, hourEnd, minEnd, 0);
                    this.Context.OfficeHours.Add(newOfficeHour);
                }
                else if (dayOfWeek.Equals("Tuesday"))
                {
                    OfficeHour newOfficeHour = new OfficeHour();
                    newOfficeHour.Course = c;
                    newOfficeHour.Student = s;
                    newOfficeHour.Start = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 5, hourStart, minStart, 0);
                    newOfficeHour.End = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 5, hourEnd, minEnd, 0);
                    this.Context.OfficeHours.Add(newOfficeHour);
                }
                else if (dayOfWeek.Equals("Wednesday"))
                {
                    OfficeHour newOfficeHour = new OfficeHour();
                    newOfficeHour.Course = c;
                    newOfficeHour.Student = s;
                    newOfficeHour.Start = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 6, hourStart, minStart, 0);
                    newOfficeHour.End = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 6, hourEnd, minEnd, 0);
                    this.Context.OfficeHours.Add(newOfficeHour);
                }
                else if (dayOfWeek.Equals("Thursday"))
                {
                    OfficeHour newOfficeHour = new OfficeHour();
                    newOfficeHour.Course = c;
                    newOfficeHour.Student = s;
                    newOfficeHour.Start = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 7, hourStart, minStart, 0);
                    newOfficeHour.End = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 7, hourEnd, minEnd, 0);
                    this.Context.OfficeHours.Add(newOfficeHour);
                }
                else if (dayOfWeek.Equals("Friday"))
                {
                    OfficeHour newOfficeHour = new OfficeHour();
                    newOfficeHour.Course = c;
                    newOfficeHour.Student = s;
                    newOfficeHour.Start = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 8, hourStart, minStart, 0);
                    newOfficeHour.End = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 8, hourEnd, minEnd, 0);
                    this.Context.OfficeHours.Add(newOfficeHour);
                }

                this.Context.SaveChanges();

            }
        }

        public void BulkInsert(String nuid, int year, int month, int day, int hour, int min, int sec)
        {
            var student = this.GetStudents().FirstOrDefault(x => x.Nuid == nuid);

            if (student != null)
            {
                student.InSRC = !student.InSRC;
                this.GetStudents().FirstOrDefault(x => x.StudentID == student.StudentID).InSRC = student.InSRC;

                this.Context.SaveChanges();

                SRCTimestamp newStamp = new SRCTimestamp();
                newStamp.Stamp = new DateTime(year, month, day, hour, min, sec);
                newStamp.Student = student;
                newStamp.WasCheckIn = student.InSRC;
                this.Context.Timestamps.Add(newStamp);

                this.Context.SaveChanges();
            }
        }
    }
}