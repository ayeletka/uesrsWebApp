

using System.Web.Mvc;

namespace myWebApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddUser()
        {
            string user = Request.Form[0];
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Collecting Users Names";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}