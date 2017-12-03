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

            return View();
        }

        [HttpPost]
        public ActionResult addTA(string nuid, string hourStart, string hourEnd, string courseNum)
        {
            AdministratorService AdministratorService = new AdministratorService();
            AdministratorService.AddTA(nuid, hourStart, hourEnd, courseNum);

            return View();
        }
    }
}