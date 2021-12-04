using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineEgitim.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Anasayfa()
        {
            ViewBag.Title = "Home Page";

            return View();
        }  public ActionResult Profil()
        {
            ViewBag.Title = "Home Page";

            return View();
        }
    }
}
