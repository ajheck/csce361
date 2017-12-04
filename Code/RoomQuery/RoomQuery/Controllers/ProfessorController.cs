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
        int courseID = 0;

        // GET: 
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
            List<HoursChartViewModel> HoursChartList = new List<HoursChartViewModel>();
            ProfessorService ProfessorService = new ProfessorService();

            courseID = ProfessorService.GetCourseByEmail(User.Identity.Name);
            DateTime startDate = new DateTime (2017, 8, 20);

            var HoursPerWeek = ProfessorService.GetClassHoursInSRC(courseID, startDate);

            foreach(var num in HoursPerWeek)
            {
                HoursChartViewModel HoursChartVM = new HoursChartViewModel();

                HoursChartVM.ClassHours = num;

                HoursChartList.Add(HoursChartVM);
            }

            var hourWeeklyJSON = Content(JsonConvert.SerializeObject(HoursChartList), "application/json");


            return hourWeeklyJSON;
        }


        //For a given course, return the data for the number of uses the SRC each week
        public ContentResult GetDataNumStudentUsage()
        {
            List<NumStudentChartViewModel> NumStudentList = new List<NumStudentChartViewModel>();
            ProfessorService ProfessorService = new ProfessorService();

            courseID = ProfessorService.GetCourseByEmail(User.Identity.Name);


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

        [HttpPost]
        public ActionResult modifyOfficeHours(string nuid, string origDayOfWeek, string origHourStart, string origMinStart, string origHourEnd, string origMinEnd, string courseNum,
            string modDayOfWeek, string modHourStart, string modMinStart, string modHourEnd, string modMinEnd)
        {
            ProfessorService ProfessorService = new ProfessorService();
            ProfessorService.ModifyHours(nuid, origDayOfWeek, Convert.ToInt32(origHourStart), Convert.ToInt32(origMinStart), Convert.ToInt32(origHourEnd), Convert.ToInt32(origMinEnd),
                modDayOfWeek, Convert.ToInt32(modHourStart), Convert.ToInt32(modMinStart), Convert.ToInt32(modHourEnd), Convert.ToInt32(modMinEnd), courseNum);

            return View("Index", model);
        }

    }
}