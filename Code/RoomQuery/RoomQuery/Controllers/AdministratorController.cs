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
    }
}