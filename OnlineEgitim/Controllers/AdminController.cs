using OnlineEgitim.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineEgitim.Controllers
{
    public class AdminController : Controller
    {
        private OnlineEgitimEntities2 db = new OnlineEgitimEntities2();

        // GET: Admin
        public ActionResult AdminAnasayfa()
        {
            return View();
        }

        public ActionResult Egitimler()
        {
            ViewModel model = new ViewModel();

            model.KursLinks = db.KursLink.ToList();
            model.Kurss = db.Kurs.ToList();
            model.Kategoris = db.Kategori.ToList();

            return View(model);
        }

        public ActionResult EgitmenBasvuru()
        {
            ViewModel model = new ViewModel();
            model.EgitimVerens = db.EgitimVeren.ToList();
            return View(model);
        }

        [HttpPost]
        public ActionResult EgitmenOnay(int id)
        {
            ViewModel model = new ViewModel();
            EgitimVeren egitimveren = new EgitimVeren();
            model.EgitimVerens = db.EgitimVeren.ToList();
            var egitmenonay = (from o in db.EgitimVeren where o.egitimVerenId == id select o).FirstOrDefault();
            var onay = db.EgitimVeren.Find(id);

            if (egitmenonay != null)
            {
                onay.OnayliMi = true;
                db.Entry(onay).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            return RedirectToAction("AdminAnasayfa", "Admin");
        }

        public ActionResult EgitmenOnay()
        {
            return View();
        }

        public ActionResult EgitmenBasvuruDetay(int id)
        {
            ViewModel model = new ViewModel();
            EgitimVeren egitimveren = new EgitimVeren();
            model.EgitimVerens = (from o in db.EgitimVeren where o.kullaniciid == id select o).ToList();
            model.Egitims = (from b in db.Egitim where b.kullaniciid == id select b).ToList();
            Session["egitimverenid"] = id;
            model.Kategoris = db.Kategori.ToList();
            return View(model);
        }

        public ActionResult Kullanicilar()
        {
            ViewModel model = new ViewModel();
            model.KullaniciBilgis = db.KullaniciBilgi.ToList();
            model.Kullanicis = db.Kullanici.ToList();
            model.Yetkis = db.Yetki.ToList();
            model.YetkiTurs = db.YetkiTur.ToList();
            var kullanicibilgi = (from b in db.KullaniciBilgi select b).FirstOrDefault();
            var yetkituru = (from o in db.Yetki select o).FirstOrDefault();
            var yetki = (from YetkiTurAd in db.YetkiTur select YetkiTurAd).FirstOrDefault();

            return View(model);
        }

        public ActionResult Egitmenler()
        {
            ViewModel model = new ViewModel();
            model.KullaniciBilgis = db.KullaniciBilgi.ToList();
            model.Kullanicis = db.Kullanici.ToList();
            model.Yetkis = db.Yetki.ToList();
            model.YetkiTurs = db.YetkiTur.ToList();
            var kullanicibilgi = (from b in db.KullaniciBilgi select b).FirstOrDefault();
            var yetkituru = (from o in db.Yetki select o).FirstOrDefault();
            var yetki = (from YetkiTurAd in db.YetkiTur select YetkiTurAd).FirstOrDefault();

            return View(model);
        }

        public ActionResult AdminProfil()
        {
            ViewModel model = new ViewModel();
            model.KullaniciBilgis = db.KullaniciBilgi.ToList();
            return View(model);
        }

        [HttpPost]
        public ActionResult AdminProfil(KullaniciBilgi kullanicibilgi)
        {
            ViewModel model = new ViewModel();
            if (kullanicibilgi != null)
            {
                model.KullaniciBilgis = db.KullaniciBilgi.ToList();
            }
            kullanicibilgi.kullaniciid = Convert.ToInt32(Session["kullanicid"]);
            kullanicibilgi.yetkiturad = Convert.ToString(Session["yetkiturad"]);
            db.KullaniciBilgi.Add(kullanicibilgi);

            db.SaveChanges();
            return RedirectToAction("AdminAnasayfa", "Admin");
        }
    }
}