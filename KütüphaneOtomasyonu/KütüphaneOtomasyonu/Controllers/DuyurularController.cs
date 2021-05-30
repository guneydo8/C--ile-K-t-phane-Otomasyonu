using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KütüphaneOtomasyonu.Models.Entity;


namespace KütüphaneOtomasyonu.Controllers
{
    public class DuyurularController : Controller
    {
        // GET: Duyurular
        MvcKütüphaneEntities db = new MvcKütüphaneEntities();

        
        public ActionResult Index()
        {
            var liste = db.TblDuyurular.ToList();
            return View(liste);
        }
        [HttpGet]
      
        public ActionResult YeniDuyuru()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniDuyuru(TblDuyurular x)
        {
            db.TblDuyurular.Add(x);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Sil(int id)
        {
            var y = db.TblDuyurular.Find(id);
            db.TblDuyurular.Remove(y);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Güncelle(int id)
        {
            var x = db.TblDuyurular.Find(id);
            return View(x);
        }

        public ActionResult Güncelle2(TblDuyurular x)
        {
            var güncelle = db.TblDuyurular.Find(x.Id);
            güncelle.Konu = x.Konu;
            güncelle.İçerik = x.İçerik;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

      
    }
}