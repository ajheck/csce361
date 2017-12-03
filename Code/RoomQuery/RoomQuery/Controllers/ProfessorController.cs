using RoomQuery.Models;
using RoomQuery.WebAppBuisnessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;


namespace RoomQuery.Controllers
{
    [Authorize(Roles = "Professor")]
    public class ProfessorController : Controller
    {
        private string model;

        // GET: Professor
        public ActionResult Index()
        {
            HomeService HomeService = new HomeService();
            HomeService.ScrubStaleEntries();
            
            return View();
        }

        public JsonResult data()
        {
            return null;
        }


        //Given a coursID, return the data for class' SRC usage hours by week
        public ContentResult GetHoursClassUsage()
        {
            List<HoursChartViewModel> HoursChartVM = new List<HoursChartViewModel>();
            //ProfessorService ProfessorService = new 

            return null;
        }

        //Given a student, return the data for student
        public ContentResult GetDataStudentUsage()
        {


            return null;
        }

        //For a given course, return the data for the number of uses the SRC each week
        public ContentResult GetDataNumStudentUsage()
        {
            List<NumStudentChartViewModel> NumStudentList = new List<NumStudentChartViewModel>();
            ProfessorService ProfessorService = new ProfessorService();

            int courseID = 2; //Temp courseID
            DateTime startDate = new DateTime (2017, 8, 20); //Beginning of the School year

            var NumStudentsPerWeek = ProfessorService.getNumStudentsPerWeek(courseID, startDate);

            foreach(var num in NumStudentsPerWeek)
            {
                NumStudentChartViewModel NumStudentsVM = new NumStudentChartViewModel();

                NumStudentsVM.NumStudents = num;

                NumStudentList.Add(NumStudentsVM);
            }


            var numStudentJSON = Content(JsonConvert.SerializeObject(NumStudentList), "application/json");
            return numStudentJSON;
        }

    }
}