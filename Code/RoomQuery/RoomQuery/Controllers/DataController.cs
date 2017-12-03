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

        [HttpPost]
        public ActionResult BulkUpload(string dataString)
        {
            string[] entries;
            char[] delimiterChars = { ' ', ';', '\n', '\r', '\t' };
            entries = dataString.Split(delimiterChars, StringSplitOptions.RemoveEmptyEntries);
            foreach (string e in entries)
            {
                DataService DataService = new DataService();
                string[] vars;
                char[] delimiters = { ',', ' ', '\n', '\t', '\r' };
                vars = e.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
                DataService.BulkInsert(vars[0], Convert.ToInt32(vars[1]), Convert.ToInt32(vars[2]), Convert.ToInt32(vars[3]), Convert.ToInt32(vars[4]), Convert.ToInt32(vars[5]), Convert.ToInt32(vars[6]));
            }

            return View("InsertData", model);
        }
    }
}