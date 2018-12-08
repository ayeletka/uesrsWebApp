

using System.Web.Mvc;
using myWebApp.Models;
using System.Web;
using System.Collections.Generic;
using System.Linq;


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
            string userName = Request.Form[0];
            Users currUsersList = new Users();
            //Users userDBTmp = (Users) HttpContext.Application["userDB"];
            //HttpContext.Application["userDB"] = userDBTmp;
            currUsersList.AddUserName(userName);
            return View("~/Views/Home/CollectingUsersNames.cshtml");
        }

        public ActionResult ShowUsers()
        {
            var usersList = new Users().getUsersList();
            return View("~/Views/Home/ShowUserslist.cshtml", usersList);
        }

        public ActionResult CollectingUsersNames()
        {
            ViewBag.Message = "Collecting User Names";
            return View();
        }

        public ActionResult ShowUserslist()
        {
            ViewBag.Message = "Click the button to see all users";
            return View("~/Views/Home/ShowUserslist.cshtml", new List<UserData>());
        }
    }
}