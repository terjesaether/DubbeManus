using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DubbeManus.Models;

namespace DubbeManus.Controllers
{
    public class HomeController : Controller
    {
        private NordubbContext _db = new NordubbContext();
        public ActionResult Index()
        {

            ViewBag.SeriesId = new SelectList(_db.Series, "SeriesId", "OrigName");
            //ViewBag.EpisodeId = new SelectList(_db.Episodes.Where(e => e.SeriesId == id), "EpisodeId", "OrigName");

            return View();
        }
        [HttpPost]
        public ActionResult Index(string SeriesId)
        {
            ViewBag.ChosenSeriesId = SeriesId;
            ViewBag.SeriesId = new SelectList(_db.Series, "SeriesId", "OrigName");
            int id = Convert.ToInt32(SeriesId);
            ViewBag.EpisodeId = new SelectList(_db.Episodes.Where(e => e.SeriesId == id), "EpisodeId", "OrigName");

            return View();
        }



        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}