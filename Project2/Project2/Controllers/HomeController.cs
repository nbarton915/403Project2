using Project2.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Project2.Models;
using System.Web.Security;
using System.Net;


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
            //IEnumerable<MissionSpecQuestions> MissionSpecQuestions = db.Database.SqlQuery


            
            return View("MissionFaqs");
        }
        #endregion

        #region Login
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(FormCollection form, bool rememberMe = false)
        {
            String email = form["Email address"].ToString();
            string password = form["Password"].ToString();

            var queryResult = db.Database.SqlQuery<Users>(
                "SELECT * " +
                "FROM Users " +
                "WHERE userEmail = '" + email + "' AND password = '" + password + "';"
                );

            if (queryResult.Count() > 0)
            {
                FormsAuthentication.SetAuthCookie(email, rememberMe);

                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();
            }

        }
        #endregion

        #region Logoff
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            Session.Abandon();
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
        #endregion

        #region Register
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register([Bind(Include = "userEmail, password, firstName, lastName")] Users users)
        {
            if (ModelState.IsValid)
            {
                string email = users.userEmail;
                bool rememberMe = false;

                db.User.Add(users);
                db.SaveChanges();

                FormsAuthentication.SetAuthCookie(email, rememberMe);

                return RedirectToAction("Index", "Home");
            }

            return View(users);
        }
        #endregion

    }
}