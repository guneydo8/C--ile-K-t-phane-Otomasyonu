using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KütüphaneOtomasyonu.Models.Entity;
using System.Web.Security;

namespace KütüphaneOtomasyonu.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        MvcKütüphaneEntities db = new MvcKütüphaneEntities();

        // GET: Login
        
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult Index(TblÜyeler x)
        {
            var giriş = db.TblÜyeler.FirstOrDefault(y => y.Mail == x.Mail && y.Şifre == x.Şifre);
            if (giriş != null)
            {
                FormsAuthentication.SetAuthCookie(giriş.Mail, false);
                Session["Mail"]=giriş.Mail.ToString();
                //TempData["id"] = giriş.Id.ToString();
                //TempData["Ad"] = giriş.Ad.ToString();
                //TempData["Soyad"] = giriş.Soyad.ToString();
                //TempData["Kullanıcı"] = giriş.KullanıcıAd.ToString();
                //TempData["Şifre"] = giriş.Şifre.ToString();
                //TempData["Telefon"] = giriş.Telefon.ToString();
                //TempData["Okul"] = giriş.Okul.ToString();
                return RedirectToAction("Index", "Kullanıcı");
            }

            else
            {

                return View();
            }
        }

        [HttpGet]
        public ActionResult Kayıtol()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Kayıtol(TblÜyeler x)
        {
            x.Durum = true;
            db.TblÜyeler.Add(x);
            db.SaveChanges();
            return RedirectToAction("Index");



        }
    }
}