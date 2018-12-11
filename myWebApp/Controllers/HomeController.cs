

namespace myWebApp.Controllers
{
    using System.Threading.Tasks;
    using System;
    using System.Web.Mvc;
    using myWebApp.Models;
    using System.Collections.Generic;
    using Microsoft.ApplicationInsights;

    public class HomeController : Controller
    {
        private readonly TelemetryClient _telemetry;
        private readonly IUsersRepository _usersRepository;

        public HomeController()
        {
            _telemetry = new TelemetryClient();
            _usersRepository = new CosmosDbUsersRepository();
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> AddUser()
        {
            string userName = Request.Form[0];
            _telemetry.TrackTrace($"Adding user '{userName}'");
            _usersRepository.AddUser(new User{ Name = userName});
            _telemetry.TrackMetric("NewUser", 1);

            return View("~/Views/Home/CollectingUsersNames.cshtml");
        }

        public async Task<ActionResult> GetUsers()
        {
            _telemetry.TrackTrace("Showing users list");

            List<string> usersList = await _usersRepository.GetUsers();
            _telemetry.TrackTrace($"Showing users list with '{usersList.Count}' users");
            _telemetry.TrackMetric("show list", usersList.Count);

            return View("~/Views/Home/ShowUserslist.cshtml", usersList);
        }

        public ActionResult CollectingUsersNames()
        {
            ViewBag.Message = "Collecting Users";
            _telemetry.TrackTrace("Showing empty tab for adding user");

            return View();
        }

        public ActionResult ShowUserslist()
        {
            ViewBag.Message = "Click the button to see all users";
            _telemetry.TrackTrace("Showing empty users list");

            return View("~/Views/Home/ShowUserslist.cshtml", new List<string>());
        }
    }
}