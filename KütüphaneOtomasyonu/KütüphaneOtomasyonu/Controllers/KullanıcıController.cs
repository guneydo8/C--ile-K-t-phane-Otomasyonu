using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using KütüphaneOtomasyonu.Models.Entity;

namespace KütüphaneOtomasyonu.Controllers
{
    [Authorize]
    public class KullanıcıController : Controller
    {
        // GET: Kullanıcı
        MvcKütüphaneEntities db = new MvcKütüphaneEntities();
       
        
        public ActionResult Index()
        {

            var kullanıcı = (string)Session["Mail"];
            //var üyegetir = db.TblÜyeler.FirstOrDefault(x => x.Mail == kullanıcı);
            var üyegetir = db.TblDuyurular.ToList();
            var deger1 = db.TblÜyeler.Where(x => x.Mail == kullanıcı).Select(y => y.Ad).FirstOrDefault();
            var deger2 = db.TblÜyeler.Where(x => x.Mail == kullanıcı).Select(y => y.Soyad).FirstOrDefault();
            var deger3 = db.TblÜyeler.Where(x => x.Mail == kullanıcı).Select(y => y.Fotoğraf).FirstOrDefault();
            var deger4 = db.TblÜyeler.Where(x => x.Mail == kullanıcı).Select(y => y.KullanıcıAd).FirstOrDefault();
            var deger5 = db.TblÜyeler.Where(x => x.Mail == kullanıcı).Select(y => y.Telefon).FirstOrDefault();
            var deger7 = db.TblÜyeler.Where(x => x.Mail == kullanıcı).Select(y => y.Okul).FirstOrDefault();
            var deger8 = db.TblÜyeler.Where(x => x.Mail == kullanıcı).Select(y => y.Tblİşlemler.Count()).FirstOrDefault();
            var deger9 = db.TblÜyeler.Where(x => x.Mail == kullanıcı).Select(y => y.Id).FirstOrDefault();
            var deger10 = db.Tblİşlemler.Where(x => x.Üye == deger9).Select(y => y.TblKitaplar.Ad).FirstOrDefault();
            var deger11 = db.TblMesajlar.Where(x => x.Alıcı == kullanıcı).Count();
            
            ViewBag.d1 = deger1;
            ViewBag.d2 = deger2;
            ViewBag.d3 = deger3;
            ViewBag.d4 = deger4;
            ViewBag.d5 = deger5;
            ViewBag.d6 = kullanıcı;
            ViewBag.d7 = deger7;
            ViewBag.d8 = deger8;
            ViewBag.d10 = deger10;
            ViewBag.d11 = deger11;
            return View(üyegetir);
        }

        [HttpPost]
       
        public ActionResult Güncelle(TblÜyeler x)
        {
            var bul = (string)Session["Mail"];
            var üye = db.TblÜyeler.FirstOrDefault(y => y.Mail == bul);
            üye.Şifre = x.Şifre;
            üye.Ad = x.Ad;
            üye.Fotoğraf = x.Fotoğraf;
            üye.KullanıcıAd = x.KullanıcıAd;
            üye.Okul = x.Okul;
            üye.Soyad = x.Soyad;
            üye.Telefon = x.Telefon;
           
            
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Login");
        }

        public PartialViewResult partial1()
        {
            return PartialView();
        }

        public PartialViewResult partial2()
        {

            var bul = (string)Session["Mail"];
            var ıd = db.TblÜyeler.Where(x => x.Mail == bul).Select(y=>y.Id).FirstOrDefault();
            var getir = db.TblÜyeler.Find(ıd);
            return PartialView("partial2",getir);
        }
    }
}