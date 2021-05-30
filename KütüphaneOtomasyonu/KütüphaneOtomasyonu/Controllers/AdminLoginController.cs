using KütüphaneOtomasyonu.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace KütüphaneOtomasyonu.Controllers
{
    [AllowAnonymous]
    public class AdminLoginController : Controller
    {
        // GET: AdminLogin

        MvcKütüphaneEntities db = new MvcKütüphaneEntities();
        public ActionResult AdminGiriş()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult AdminGiriş(TblAdmin x)
        {
            var giriş = db.TblAdmin.FirstOrDefault(y => y.Mail == x.Mail && y.Şifre == x.Şifre);

            if (giriş != null)
            {
                FormsAuthentication.SetAuthCookie(giriş.Mail, false);
                Session["Mail"] = giriş.Mail.ToString();
                return RedirectToAction("Index", "İstatistikler");
            }
            else
            {
                return View();
                
            }
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("AdminGiriş", "AdminLogin");
        }
    }
}