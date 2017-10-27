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
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            IndexViewModel ViewModel = new IndexViewModel();
            HomeService HomeService = new HomeService();

            HomeService.ScrubStaleEntries();

            ViewModel.Population = HomeService.GetPopulation();
            ViewModel.ActiveOfficeHours = HomeService.GetActiveOfficeHours().ToList();
            ViewModel.WeeklyOfficeHours = HomeService.GetOfficeHours().ToList();

            return View(ViewModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ContentResult GetData()
        {
            List<GraphViewModel> Home = new List<GraphViewModel>();

            HomeService HomeService = new HomeService();

            var TodayPop = HomeService.GetTodaysPopulation();
            var HistPop = HomeService.GetHistoricalPopulation();

            foreach (var Point in HistPop)
            {
                GraphViewModel AviewModel = new GraphViewModel();
                AviewModel.HistoricalPopulation = Point;
                //AviewModel.GraphLabel = "a";
                Home.Add(AviewModel);
            }

            var temp = Content(JsonConvert.SerializeObject(Home), "application/json");
            return temp;
        }
    }
}