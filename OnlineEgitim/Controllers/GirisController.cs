using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using OnlineEgitim.Models;

namespace OnlineEgitim.Controllers
{
    public class GirisController : Controller
    {
        // GET: Giris
        private OnlineEgitimEntities2 db = new OnlineEgitimEntities2();

        [AllowAnonymous]
        public ActionResult Girisyap()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult GirisYap(string kullaniciadi, string sifre)
        {
            var kullanici = (from k in db.Kullanici where k.Kullaniciadi == kullaniciadi && k.Sifre == sifre select k).FirstOrDefault();
            if (kullanici != null)
            {
                Session["kullaniciad"] = kullanici.Kullaniciadi;
                Session["kullanicid"] = kullanici.KullaniciId;

                var yetki = (from y in db.Yetki where y.KullaniciId == kullanici.KullaniciId select y).FirstOrDefault();
                Session["yetkiid"] = yetki.YetkiId;

                if (yetki.YetkiTurId == 1)
                {
                    FormsAuthentication.SetAuthCookie(kullanici.Kullaniciadi, false);
                    return RedirectToAction("Admin", "Admin");
                }
                if (yetki.YetkiTurId == 2)
                {
                    FormsAuthentication.SetAuthCookie(kullanici.Kullaniciadi, false);

                    return RedirectToAction("Egitmen", "Egitmen");
                }
                if (yetki.YetkiTurId == 3)
                {
                    Session["kullaniciid"] = kullanici.KullaniciId;

                    FormsAuthentication.SetAuthCookie(kullanici.Kullaniciadi, false);
                    return RedirectToAction("Anasayfa", "Home");
                }
            }
            else
            {
                TempData["mesajgiris"] = "Hatalı kulanıcı adı veya şifre. Lütfen tekrar deneyiniz.";
                return View();
            }
            return View();
        }

        public ActionResult AdminGiris()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AdminGiris(string kullaniciadi, string sifre)
        {
            var kullanici = (from k in db.Kullanici where k.Kullaniciadi == kullaniciadi && k.Sifre == sifre select k).FirstOrDefault();
            if (kullanici != null)
            {
                Session["kullaniciad"] = kullanici.Kullaniciadi;
                Session["kullanicid"] = kullanici.KullaniciId;

                var yetki = (from y in db.Yetki where y.KullaniciId == kullanici.KullaniciId select y).FirstOrDefault();
                Session["yetkiid"] = yetki.YetkiId;

                if (yetki.YetkiTurId == 1)
                {
                    FormsAuthentication.SetAuthCookie(kullanici.Kullaniciadi, false);
                    return RedirectToAction("AdminAnasayfa", "Admin");
                }
            }
            else
            {
                TempData["mesajgiris"] = "Hatalı kulanıcı adı veya şifre. Lütfen tekrar deneyiniz.";
                return View();
            }
            return View();
        }

        [HttpPost]
        public ActionResult UyeOl(string kullaniciad, string sifre)
        {
            Yetki yetki = new Yetki();
            Kullanici kullanici = new Kullanici();
            kullanici.Kullaniciadi = kullaniciad;
            kullanici.Sifre = sifre;
            db.Kullanici.Add(kullanici);
            db.SaveChanges();
            yetki.KullaniciId = kullanici.KullaniciId;
            yetki.YetkiTurId = 3;
            db.Yetki.Add(yetki);
            db.SaveChanges();
            return RedirectToAction("Anasayfa", "Home");
        }

        public ActionResult Cikis()
        {
            Session["yetkiid"] = null;
            FormsAuthentication.SignOut();
            return RedirectToAction("GirisYap", "Giris");
        }

        public ActionResult AdminCikis()
        {
            Session["yetkiid"] = null;
            FormsAuthentication.SignOut();
            return RedirectToAction("AdminGiris", "Giris");
        }
    }
}