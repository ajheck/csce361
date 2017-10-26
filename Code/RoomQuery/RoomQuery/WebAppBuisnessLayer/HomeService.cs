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
        public IEnumerable<Student> GetStudents()
        {
            return Context.Students.Where(x => x != null);
        }

        /*
         * Return all Students who are checked in in the database
         */
        public IEnumerable<Student> GetCurrentStudents()
        {
            return this.GetStudents().Where(x => x.InSRC == true);
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
            return this.GetStudents().Where(x => x.IsTA == true);
        }

        /*
         * Return all students who are in the SRC and are TAs and are curreently hosting office hours
         */
        public IEnumerable<Student> GetActiveTAs()
        {
            // Get students who are  in SRC who are TAs
            var possibleActiveTAs = this.GetTAs().Where(x => x.InSRC == true);

            // Get office hours which are happening right now
            var currentOfficeHours = this.GetCurrentOfficeHours();

            // For each entry x in possibleActiveTas, check if currentOfficeHours has a corresponding Student
            var activeTAs = possibleActiveTAs.Where(x => currentOfficeHours.Select(y => y.Student.StudentID).Contains(x.StudentID));

            return activeTAs;
        }

        /*
         * Get all entries of office hours
         */
        public IEnumerable<OfficeHour> GetOfficeHours()
        {
            return Context.OfficeHours.Where(x => x != null);
        }

        /*
         * For a given Student TA, return all of their office hours 
         */
        public IEnumerable<OfficeHour> GetOfficeHours(Student TA)
        {
            return this.GetOfficeHours().Where(x => x.Student.StudentID == TA.StudentID);
        }
        
        /*
         * Return all office hours that are occuring right now
         */
        public IEnumerable<OfficeHour> GetCurrentOfficeHours()
        {
            return this.GetOfficeHours().Where(x => x.Start < DateTime.Now && x.End > DateTime.Now);
        }

        /*
         * For a given Student TA, return their current office hours
         */
        public IEnumerable<OfficeHour> GetCurrentOfficeHours(Student TA)
        {
            return this.GetCurrentOfficeHours().Where(x => x.Student.StudentID == TA.StudentID);
        }

        /*
         * Return all office hours which are currently happneing and that have a TA present
         */
        public IEnumerable<OfficeHour> GetActiveOfficeHours()
        {
            return this.GetCurrentOfficeHours().Where(x => x.Student.InSRC == true);
        }
    }
}