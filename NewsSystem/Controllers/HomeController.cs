using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NewsSystem.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Login()
        {
            ViewBag.Title = "Home Page";

            return View("Login");
        }

        public ActionResult View()
        {
            ViewBag.Title = "View Page";

            return View("View");
        }




    }
}
