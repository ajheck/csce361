using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RoomQuery.DataCollectionBuisnessLayer;

namespace RoomQuery.Controllers
{
    public class DataController : Controller
    {
        private string model;

        public ActionResult InsertData()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Submit(string nuid)
        {
            DataService DataService = new DataService();
            DataService.HandleScan(nuid);

            return View("InsertData", model);
        }
    }
}