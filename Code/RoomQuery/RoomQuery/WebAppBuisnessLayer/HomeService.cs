using RoomQuery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RoomQuery.WebAppBuisnessLayer
{
    /*
     * Provides buisness logic and access to WebApp Data Access Layer for WebApp UI layer
     */
    public class HomeService
    {
        private ApplicationDbContext Context = ApplicationDbContext.Create();

        /*
         * Return all Students in the database
         */
        public IEnumerable<Student> GetAllStudents()
        {
            return Context.Students;
        }

        /*
         * Return all Students who are checked in in the database
         */
        public IEnumerable<Student> GetCurrentStudents()
        {
            return Context.Students.Where(x => x.InSRC == true);
        }

        /*
         * Returns current population of SRC
         */
        public int GetPopulation()
        {
            return this.GetCurrentStudents().Count();
        }

        /*
         * Return all Students who are a TA
         */
        public IEnumerable<Student> GetTAs()
        {
            return Context.Students.Where(x => x.IsTA == true);
        }

        /*
         * Return all students who are in the SRC and are TAs and are curreently hosting office hours
         */
        public IEnumerable<Student> GetCurrentTAs()
        {
            // Get students who are  in SRC who are TAs
            var possibleActiveTAs = Context.Students.Where(x => x.IsTA == true && x.InSRC == true);

            // Get ofccie hours which are happening right now
            var currentOfficeHours = Context.OfficeHours.Where(x => DateTime.Compare(x.Start, DateTime.Now) > 0 && DateTime.Compare(x.Start, DateTime.Now) < 0);

            // For each entry x in possibleActiveTas, check if currentOfficeHours has a corresponding Student
            var currentTAs = possibleActiveTAs.Where(x => currentOfficeHours.Select(y => y.Student.StudentID).Contains(x.StudentID));

            return currentTAs;
        }

        /*
         * For a given Student TA, return all of their office hours 
         */
        public IEnumerable<OfficeHour> GetOfficeHours(Student TA)
        {
            return Context.OfficeHours.Where(x => x.Student.StudentID == TA.StudentID);
        }

        /*
         * For a given Student TA, return their current office hours
         */
         public IEnumerable<OfficeHour> GetCurrentOfficeHours(Student TA)
        {
            return this.GetOfficeHours(TA).Where(x => DateTime.Compare(x.Start, DateTime.Now) > 0 && DateTime.Compare(x.Start, DateTime.Now) < 0);
        }

    }
}