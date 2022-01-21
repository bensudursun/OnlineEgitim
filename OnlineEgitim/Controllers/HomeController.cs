using OnlineEgitim.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineEgitim.Controllers
{
    public class HomeController : Controller
    {
        private OnlineEgitimEntities2 db = new OnlineEgitimEntities2();

        public ActionResult Anasayfa()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        [HttpPost]
        public ActionResult Profil(KullaniciBilgi kullanicibilgi)
        {
            ViewModel model = new ViewModel();
            if (kullanicibilgi != null)
            {
                model.KullaniciBilgis = db.KullaniciBilgi.ToList();
            }
            db.KullaniciBilgi.Add(kullanicibilgi);
            kullanicibilgi.kullaniciid = Convert.ToInt32(Session["kullaniciid"]);
            db.SaveChanges();
            return RedirectToAction("Anasayfa", "Home");
        }

        public ActionResult Profil()
        {
            ViewModel model = new ViewModel();
            model.KullaniciBilgis = db.KullaniciBilgi.ToList();
            return View(model);
        }

        [HttpPost]
        public ActionResult SifreGuncelle(string eskisifre, string yenisifre, string yenisifretekrar)
        {
            ViewModel model = new ViewModel();
            Kullanici kullanici = new Kullanici();
            model.Kullanicis = db.Kullanici.ToList();
            var silineceksifre = db.Kullanici.FirstOrDefault(x => x.Sifre == eskisifre);
            var kullaniciids = Convert.ToInt32(Session["Kullaniciid"]);
            var kullanicisil = db.Kullanici.FirstOrDefault(x => x.KullaniciId == kullaniciids);
            if (yenisifre == yenisifretekrar)
            {
                var yenikullanici = db.Kullanici.Find(kullaniciids);

                db.Entry(yenikullanici).State = System.Data.Entity.EntityState.Modified;

                db.SaveChanges();
            }

            return RedirectToAction("Profil", "Home");
        }

        public ActionResult EgitmenBasvuru()
        {
            return View();
        }

        [HttpPost]
        public ActionResult EgitmenBasvuru(EgitimVeren egitimveren)
        {
            db.EgitimVeren.Add(egitimveren);
            db.SaveChanges();
            return View();
        }
    }
}