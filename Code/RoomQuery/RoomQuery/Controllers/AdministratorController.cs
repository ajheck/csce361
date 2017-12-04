using RoomQuery.WebAppBuisnessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RoomQuery.Controllers
{
    [Authorize (Roles = "Admin")]
    public class AdministratorController : Controller
    {
        private string model;

        // GET: Administrator
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult changeTAStatus(string nuid)
        {
            AdministratorService AdministratorService = new AdministratorService();
            AdministratorService.ModifyTAStatus(nuid);

            return View("Index", model);
        }

        [HttpPost]
        public ActionResult addTA(string nuid, string dayOfWeek, string hourStart, string minStart, string hourEnd, string minEnd, string courseNum)
        {
            AdministratorService AdministratorService = new AdministratorService();
            AdministratorService.AddTA(nuid, dayOfWeek, Convert.ToInt32(hourStart), Convert.ToInt32(minStart), Convert.ToInt32(hourEnd), Convert.ToInt32(minEnd), courseNum);

            return View("Index", model);
        }

        [HttpPost]
        public ActionResult BulkUpload(string dataString)
        {
            string[] entries;
            char[] delimiterChars = { ' ', ';', '\n', '\r', '\t' };
            entries = dataString.Split(delimiterChars, StringSplitOptions.RemoveEmptyEntries);
            foreach (string e in entries)
            {
                AdministratorService DataService = new AdministratorService();
                string[] vars;
                char[] delimiters = { ',', ' ', '\n', '\t', '\r' };
                vars = e.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
                DataService.BulkInsert(vars[0], Convert.ToInt32(vars[1]), Convert.ToInt32(vars[2]), Convert.ToInt32(vars[3]), Convert.ToInt32(vars[4]), Convert.ToInt32(vars[5]), Convert.ToInt32(vars[6]));
            }

            return View("InsertData", model);
        }
    }
}