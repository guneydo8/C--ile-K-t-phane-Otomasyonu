using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KütüphaneOtomasyonu.Models.Entity;
using PagedList.Mvc;
using PagedList;

namespace KütüphaneOtomasyonu.Controllers
{
    public class KategoriController : Controller
    {
        MvcKütüphaneEntities db = new MvcKütüphaneEntities();
        // GET: Kategori
        public ActionResult Index(int sayfa=1)
        {
            var liste = db.TblKategoriler.Where(x=>x.Durum==true).ToList().ToPagedList(sayfa,5);
            //var liste = db.TblKategoriler.ToList();
            return View(liste);
        }

        [HttpGet]
        public ActionResult Ekle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Ekle(TblKategoriler x)
        {
            if (!ModelState.IsValid)
            {
                return View("Ekle");
            }
            db.TblKategoriler.Add(x);
            db.SaveChanges();
            return RedirectToAction("Index");
          
        }

        public ActionResult Sil(int id)
        {
            var rmv = db.TblKategoriler.Find(id);
            //db.TblKategoriler.Remove(rmv);
            rmv.Durum = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Güncelle(int id)
        {
            var bul = db.TblKategoriler.Find(id);
            return View("Güncelle", bul);
        }

        public ActionResult Güncelle2(TblKategoriler x)
        {
            var güncelle = db.TblKategoriler.Find(x.Id);
            güncelle.KategoriAd = x.KategoriAd;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}