

using System.Web.Mvc;
using myWebApp.Models;
using System.Web;

using myWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

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
            Users userDB = new Users();
            //Users userDBTmp = (Users) HttpContext.Application["userDB"];
            // userDBTmp.setUsersList(user);
            userDB.setUsersList(user);
            //HttpContext.Application["userDB"] = userDBTmp;
            return View("~/Views/Home/About.cshtml");
        }

      
        public ActionResult ShowUsers()
        {
            var tmp3 = new Users().getUsersList();
            return View("~/Views/Home/Contact.cshtml", tmp3);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Collecting Users Names";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            //return View(HttpContext.Application["userDB"]);

            //var tmp3 = new Users().getUsersList();
            return View("~/Views/Home/Contact.cshtml", new List<UserData>());
        }
    }
}