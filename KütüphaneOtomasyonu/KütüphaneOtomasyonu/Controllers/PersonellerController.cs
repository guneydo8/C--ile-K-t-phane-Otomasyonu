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
    public class PersonellerController : Controller
    {
        // GET: Personeller
        MvcKütüphaneEntities db = new MvcKütüphaneEntities();
        public ActionResult Index(int sayfa=1)
        {
            var liste = db.TblPersonel.ToList().ToPagedList(sayfa, 3);
            //var liste = db.TblPersonel.ToList();

            return View(liste);
        }

        [HttpGet]
        public ActionResult Ekle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Ekle(TblPersonel x)
        {
            if (!ModelState.IsValid)
            {
                return View("Ekle");

            }
            db.TblPersonel.Add(x);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Sil(int id)
        {
            var rmv = db.TblPersonel.Find(id);
            db.TblPersonel.Remove(rmv);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Güncelle(int id)
        {
            var bul = db.TblPersonel.Find(id);
            return View(bul);
        }

        public ActionResult Güncelle2(TblPersonel x)
        {
            var güncelle = db.TblPersonel.Find(x.Id);
            güncelle.AdSoyad = x.AdSoyad;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}