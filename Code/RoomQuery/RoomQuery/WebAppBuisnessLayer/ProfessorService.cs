using RoomQuery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RoomQuery.WebAppBuisnessLayer
{
    public class ProfessorService
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
         * For a given NUID, return the respective student
         */
        public Student getStudentByNUID(string nuid)
        {
            var students = Context.Students.Where(x => x.Nuid == nuid);
            Student student = students.First();
            return student;
        }

        /*
        * Return all Courses in the database
        */
        public IEnumerable<Course> GetCourse()
        {
            return Context.Courses.Where(x => x != null);
        }

        /*
         * For a given CourseID, return the course
         */
        public Course GetCourseByID(int courseID)
        {
            var courses = Context.Courses.Where(x => x.CourseID == courseID);
            Course course = courses.First();

            return course;
        }

        /*
        * For a given CourseID, return the course
        */
        public Course GetCourseByName(string courseName)
        {
            var courses = Context.Courses.Where(x => x.CourseName == courseName);
            Course course = courses.First();
            return course;
        }

        /*
        * For a given professor, return all courses
        */
        public IEnumerable<Course> GetCourseByProfessorID(String nuid)
        {
            return this.GetCourse().Where(x => x.Professor.Nuid == nuid);   
        }

        /*
        * For a given professor, return their course
        */
        public Course GetCourseByProfessorID2(int id)
        {
            return this.Context.Courses.Where(x => x.Professor.ProfessorID == id).FirstOrDefault();
        }

        /*
        * For a given email, return the course ID
        */
        public int GetCourseByEmail(string email)
        {

            ProfessorService ProfessorService = new ProfessorService();

            Professor professor = ProfessorService.GetProfessorByEmail(email);

            int nuid = professor.ProfessorID;

            Course course = ProfessorService.GetCourseByProfessorID2(nuid);

            return course.CourseID;
        }

        /*
         * For a given email, returns professor
         */
        public Professor GetProfessorByEmail(string email)
        {
            var professors = Context.Professors.Where(x => x.Email == email);

            Professor professor = professors.First();

            return professor;
        }

        /*
        * For a given course, returns number of hours students spent in SRC each week 
        */
        public List<int> GetClassHoursInSRC(int courseID, DateTime startDate)
        {
            List<int> result = new List<int>(); //List that will contain the number of hours spent by all the students in the class each week
            int timeSpent= 0;
            Course course = GetCourseByID(courseID);

            var endDate = DateTime.Now;
            endDate = endDate.AddHours(-(endDate.Hour + 1));

            var classStamps = Context.Timestamps.Where(x => x.Stamp >= startDate 
                                                        && x.Stamp < endDate).OrderBy(x => x.Stamp).ToList(); //Contains all stamps for students in a given class

            //Create a list of stamps that are associated with the students in the given course
            List<SRCTimestamp> stamps = new List<SRCTimestamp>();
            foreach (var stamp in classStamps)
            {
                if (course.Roster.Contains(stamp.Student))
                {
                    stamps.Add(stamp);
                }
            }

            var endBound = DateTime.Now;

            int difference = 0;

            SRCTimestamp checkin;


            Stack<SRCTimestamp> myStack = new Stack<SRCTimestamp>();

            while(startDate < endDate)
            {
                endBound = startDate.AddDays(7);
                timeSpent = 0;
                difference = 0;

                foreach (SRCTimestamp s in stamps)
                {
                    if(s.Stamp >= startDate 
                      && s.Stamp < endBound
                      && s.Stamp < endDate)
                    {
                        if (s.WasCheckIn)
                        {
                            myStack.Push(s);
                        }else
                        {
                            if(myStack.Count != 0)
                            {
                                checkin = myStack.Pop();
                                difference = Math.Abs(s.Stamp.Hour - checkin.Stamp.Hour);
                            }
                            timeSpent = timeSpent + difference;
                        }
                    }
                }
                result.Add(timeSpent);

                startDate = startDate.AddDays(7);                
            }
            return result;
        }

        /*
         * For a given class, returns number of students who use SRC for each week
         */
         public List<int> getNumStudentsPerWeek(int courseID, DateTime startDate)
        {
            List<int> result = new List<int>();
            int numUses = 0;
            Course course = this.GetCourseByID(courseID);

            var timeStamps = Context.Timestamps.Where(x => x != null).ToList(); //Contains all time stamps from students in a class
            DateTime endBound = DateTime.Now; //The bound for each week. This changes, as start date changes
            DateTime endDate = DateTime.Now.AddHours(-(DateTime.Now.Hour + 1)); // End date is yeterday before midnight.

            // Create a list of timestamps for students who are in the given course
            List<SRCTimestamp> stamps = new List<SRCTimestamp>();
            foreach (var stamp in timeStamps)
            {
                if (course.Roster.Contains(stamp.Student))
                {
                    stamps.Add(stamp);
                }
            }

            //Create a list containing the number of SRC uses for each week from start date to now.
            while (startDate < endDate)
            {
                endBound = startDate.AddDays(7);
                numUses = 0;

                foreach (SRCTimestamp s in stamps)
                {
                    if(s.Stamp >= startDate && s.Stamp < endBound && s.WasCheckIn && s.Stamp < endDate) //if the stamp falls within the given week and before the ultimate end date
                    {
                        numUses++;
                    }
                }

                result.Add(numUses);

                startDate = startDate.AddDays(7); //Increment start date by a week
            }

            return result; //A list containing the number of students that used the SRC, for each week
        }
    }
}