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

        public void AddTA(string n, string start, string end, string c)
        {
            var student = this.GetStudents().FirstOrDefault(x => x.Nuid == n);
            var course = this.GetCourses().Where(x => x.CourseNumber == c).FirstOrDefault();

            if (student != null && course != null)
            {
                OfficeHour newOfficeHour = new OfficeHour();
                newOfficeHour.Course = course;
                newOfficeHour.Student = student;
                newOfficeHour.Start = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 11, 0, 0).AddDays(1);
                newOfficeHour.End = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 11, 0, 0).AddDays(1).AddHours(2);
                this.Context.OfficeHours.Add(newOfficeHour);

                this.Context.SaveChanges();

            }
        }
    }
}