using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineEgitim.Controllers
{
    public class EgitmenController : Controller
    {
        // GET: Egitmen
        public ActionResult EgitmenKayit()
        {
            return View();
        }

        public ActionResult EgitmenDersEkle()
        {
            return View();
        }
    }
}