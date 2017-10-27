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

            GraphViewModel GraphViewModel = new GraphViewModel();
            HomeService HomeService = new HomeService();

            GraphViewModel.TodaysPopulation = HomeService.GetTodaysPopulation();
            GraphViewModel.HistoricalPopulation = HomeService.GetHistoricalPopulation();
            Home.Add(GraphViewModel);

            return Content(JsonConvert.SerializeObject(Home), "application/json");
        }
    }
}