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
        private OnlineEgitimEntities1 db = new OnlineEgitimEntities1();

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

        public ActionResult Cikis()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("GirisYap", "Giris");
        }
    }
}