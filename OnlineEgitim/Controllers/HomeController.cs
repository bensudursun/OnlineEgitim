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
            ViewModel model = new ViewModel();
            model.Kurss = db.Kurs.ToList();
            return View(model);
        }

        public ActionResult Egitimlerim()
        {
            ViewModel model = new ViewModel();
            model.Kurss = db.Kurs.ToList();
            return View(model);
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
            kullanicibilgi.yetkiturad = Convert.ToString(Session["yetkiturad"]);
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
                yenikullanici.Sifre = yenisifre;
                db.Entry(yenikullanici).State = System.Data.Entity.EntityState.Modified;

                db.SaveChanges();
            }

            return RedirectToAction("Profil", "Home");
        }

        public ActionResult EgitmenBasvuru()
        {
            EgitimVeren egitimveren = new EgitimVeren();

            if (egitimveren.OnayliMi == true)
            {
                Session["egitimverenonay"] = true;
            }
            return View();
        }

        public ActionResult KursEkle()
        {
            ViewModel model = new ViewModel();
            model.Kategoris = db.Kategori.ToList();
            return View(model);
        }

        [HttpPost]
        public ActionResult YorumEkle(string yorum)
        {
            Yorum yorums = new Yorum();
            yorums.kullaniciid = Convert.ToInt32(Session["Kullanicid"]);
            yorums.kursid = Convert.ToInt32(Session["kursid"]);
            yorums.Yorum1 = yorum;
            db.Yorum.Add(yorums);
            db.SaveChanges();
            return RedirectToAction("Anasayfa", "Home");
        }

        [HttpPost]
        public ActionResult KursEkle(string kursbaslik, int kategori, string aciklama, string dil, string duzey, string kursgoruntu)
        {
            Kurs kurs = new Kurs();
            kurs.kullaniciid = Convert.ToInt32(Session["Kullanicid"]);
            kurs.kategoriid = kategori;
            kurs.kursbaslik = kursbaslik;
            kurs.aciklama = aciklama;
            kurs.Dil = dil;
            kurs.Düzey = duzey;
            kurs.kursgoruntu = kursgoruntu;
            db.Kurs.Add(kurs);
            db.SaveChanges();
            return RedirectToAction("Anasayfa", "Home");
        }

        [HttpPost]
        public ActionResult KursLinkEkle(string icerikbaslik, string videoad, string videolink)
        {
            KursLink kurslink = new KursLink();
            kurslink.kursid = Convert.ToInt32(Session["kursid"]);
            kurslink.icerikbaslik = icerikbaslik;
            kurslink.videoad = videoad;
            kurslink.kursLinks = videolink;
            db.KursLink.Add(kurslink);
            db.SaveChanges();
            return RedirectToAction("Anasayfa", "Home");
        }

        public ActionResult KursDetay(int id)
        {
            ViewModel model = new ViewModel();
            Session["kursid"] = id;
            model.Yorums = (from o in db.Yorum where o.kursid == id select o).ToList();
            model.Kurss = (from o in db.Kurs where o.KursId == id select o).ToList();
            model.KursLinks = (from o in db.KursLink where o.kursid == id select o).ToList();
            return View(model);
        }

        public ActionResult EgitimVer()
        {
            ViewModel model = new ViewModel();
            model.Kategoris = db.Kategori.ToList();

            return View(model);
        }

        [HttpPost]
        public ActionResult EgitimVer(string egitimbasligi, int kategori, string aciklama)
        {
            Egitim egitim = new Egitim();
            egitim.EgitimBasligi = egitimbasligi;
            egitim.KategoriId = kategori;
            egitim.Aciklama = aciklama;
            egitim.kullaniciid = Convert.ToInt32(Session["Kullanicid"]);
            db.Egitim.Add(egitim);
            db.SaveChanges();
            return RedirectToAction("Anasayfa", "Home");
        }

        [HttpPost]
        public ActionResult EgitmenBasvuru(EgitimVeren egitimveren)
        {
            db.EgitimVeren.Add(egitimveren);
            egitimveren.kullaniciid = Convert.ToInt32(Session["Kullanicid"]);
            db.SaveChanges();
            return RedirectToAction("EgitimVer", "Home");
        }
    }
}