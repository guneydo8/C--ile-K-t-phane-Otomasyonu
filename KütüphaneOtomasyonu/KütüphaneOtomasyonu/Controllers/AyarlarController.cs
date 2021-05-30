using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KütüphaneOtomasyonu.Models.Entity;

namespace KütüphaneOtomasyonu.Controllers
{

    [Authorize (Roles ="A")]
    public class AyarlarController : Controller
    {
        MvcKütüphaneEntities db = new MvcKütüphaneEntities();
        // GET: Ayarlar
      

        public ActionResult Index2()
        {
            var liste = db.TblAdmin.ToList();
            return View(liste);
        }


        [HttpGet]
        public ActionResult YeniAdmin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniAdmin(TblAdmin x)
        {
            db.TblAdmin.Add(x);
            db.SaveChanges();
            return RedirectToAction("Index2");
        }

        public ActionResult Sil(int Id)
        {
            var bul = db.TblAdmin.Find(Id);
            db.TblAdmin.Remove(bul);
            db.SaveChanges();
            return RedirectToAction("Index2");

        }

        public ActionResult Güncelle(int Id)
        {
            var bul = db.TblAdmin.Find(Id);
            return View(bul);

        }

        public ActionResult Güncelle2(TblAdmin x)
        {
            var gnc = db.TblAdmin.Find(x.Id);
            gnc.Mail = x.Mail;
            gnc.Yetki = x.Yetki;
            gnc.Şifre = x.Şifre;
            db.SaveChanges();
            return RedirectToAction("Index2");
        }

    }
}