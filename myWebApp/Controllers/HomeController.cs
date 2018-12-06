

using System.Web.Mvc;
using myWebApp.Models;

namespace myWebApp.Controllers
{
    public class HomeController : Controller
    {
        private Users usersDB = new Users();
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddUser()
        {
            string user = Request.Form[0];
            usersDB.setUsersList(user);
            return View("~/Views/Home/About.cshtml");
        }

      
        public ActionResult ShowUsers()
        {
            return View("~/Views/Home/Contact.cshtml", usersDB);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Collecting Users Names";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View(usersDB);
        }
    }
}