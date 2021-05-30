using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KütüphaneOtomasyonu.Models.Entity;
namespace KütüphaneOtomasyonu.Controllers
{
    public class ÜyelerController : Controller
    {
        // GET: Üyeler
        MvcKütüphaneEntities db = new MvcKütüphaneEntities();
        public ActionResult Index(string x)
        {
            var liste = from k in db.TblÜyeler select k;

            if (!string.IsNullOrEmpty(x))
            {
                liste = liste.Where(t => t.Ad.Contains(x));

            }


            //var liste = db.TblÜyeler.ToList();
            return View(liste.ToList());
        }

        [HttpGet]
        public ActionResult Ekle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Ekle(TblÜyeler x)
        {
            if (!ModelState.IsValid)
            {
                return View("Ekle");
            }
            x.Durum = true;
            db.TblÜyeler.Add(x);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Sil(int id)
        {
            var bul = db.TblÜyeler.Find(id);
            db.TblÜyeler.Remove(bul);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Güncelle(int id)
        {
            var bul = db.TblÜyeler.Find(id);
            return View(bul);
        }

        public ActionResult Güncelle2(TblÜyeler x)
        {
            var güncelle = db.TblÜyeler.Find(x.Id);
            güncelle.Ad = x.Ad;
            güncelle.Soyad = x.Soyad;
            güncelle.Fotoğraf = x.Fotoğraf;
            güncelle.KullanıcıAd = x.KullanıcıAd;
            güncelle.Mail = x.Mail;
            güncelle.Okul = x.Okul;
            güncelle.Telefon = x.Telefon;
            güncelle.Şifre = x.Şifre;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

       public ActionResult ÜyeKitap(int id)
        {
            var kitap = db.Tblİşlemler.Where(x => x.Üye == id).ToList();
            return View(kitap);

        }
    }

}