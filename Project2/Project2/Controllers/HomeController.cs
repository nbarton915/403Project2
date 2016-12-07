using Project2.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace Project2.Controllers
{
    public class HomeController : Controller
    {
        private Project2Context db = new Project2Context();

        public ActionResult Index()
        {
            return View();
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

        #region Missions
        public ActionResult Missions()
        {
            ViewBag.something = db.Mission.ToList();
            return View();
        }

        #endregion

        public ViewResult SelectedMission(string selectedMission)
        {
            return View("SelectedMission");
        }

        #region MissionFaqs
        public ViewResult MissionFaqs(string missionID)
        {
            ViewBag.SelectedMission = db.Database.SqlQuery(
                "SELECT Missions.missionName " +
                "FROM Missions " +
                "WHERE Missions.missionID = " +
                missionID
                ).ToList();
            
            return View("MissionFaqs");
        }
        #endregion
    }
}