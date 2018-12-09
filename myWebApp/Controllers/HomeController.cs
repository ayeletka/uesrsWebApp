

using System;
using System.Web.Mvc;
using myWebApp.Models;
using System.Web;
using System.Collections.Generic;
using System.Linq;
using Microsoft.ApplicationInsights;


namespace myWebApp.Controllers
{
    public class HomeController : Controller
    {
        private TelemetryClient _telemetry = new Microsoft.ApplicationInsights.TelemetryClient();

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddUser()
        {
            string userName = Request.Form[0];
            Users currUsersList = new Users();
            currUsersList.AddUserName(userName);
            _telemetry.TrackTrace($"Adding user '{userName}'");
            _telemetry.TrackMetric("NewUser", 1);
            _telemetry.TrackRequest(new Microsoft.ApplicationInsights.DataContracts.RequestTelemetry());
            return View("~/Views/Home/CollectingUsersNames.cshtml");
        }

        public ActionResult ShowUsers()
        {
            var usersList = new Users().GetUsersList();
            _telemetry.TrackTrace("Showing users list");
            _telemetry.TrackTrace($"Showing users list with '{usersList.Count}' users");
            _telemetry.TrackMetric("show list",usersList.Count);

            return View("~/Views/Home/ShowUserslist.cshtml", usersList);
        }

        public ActionResult CollectingUsersNames()
        {
            ViewBag.Message = "Collecting User Names";
            _telemetry.TrackTrace("Showing empty tab for adding user");

            return View();
        }

        public ActionResult ShowUserslist()
        {
            ViewBag.Message = "Click the button to see all users";
            _telemetry.TrackTrace("Showing empty users list");

            return View("~/Views/Home/ShowUserslist.cshtml", new List<User>());
        }
    }
}