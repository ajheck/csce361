using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RoomQuery.Controllers
{
    [Authorize(Roles = "Professor")]
    public class ProfessorController : Controller
    {
        private string model;

        // GET: Professor
        public ActionResult Index()
        {
            return View();
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