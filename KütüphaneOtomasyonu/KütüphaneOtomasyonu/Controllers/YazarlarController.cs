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
    public class YazarlarController : Controller
    {
        // GET: Yazarlar
        MvcKütüphaneEntities db = new MvcKütüphaneEntities();
        public ActionResult Index(int sayfa=1)
        {
          
            //var liste = db.TblYazar.ToList();

            var liste = db.TblYazar.ToList().ToPagedList(sayfa, 6);
            return View(liste);
        }

        [HttpGet]
        public ActionResult Ekle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Ekle(TblYazar x)
        {
            if (!ModelState.IsValid)
            {
                return View("Ekle");
            }

            db.TblYazar.Add(x);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Sil(int id)
        {
            var rmv = db.TblYazar.Find(id);
            db.TblYazar.Remove(rmv);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Güncelle(int id)
        {
            var bul = db.TblYazar.Find(id);
            return View(bul);
        }

        public ActionResult Güncelle2(TblYazar x)
        {
            var güncelle = db.TblYazar.Find(x.Id);
            güncelle.Ad = x.Ad;
            güncelle.Soyad = x.Soyad;
            güncelle.Açıklama = x.Açıklama;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Detay(int id)
        {
            //var bul = db.TblYazar.Find(id);
            var liste = db.TblKitaplar.Where(y => y.Yazar ==id).ToList();
            return View(liste);
        }

        public ActionResult Hakkında(int id)
        {
            var bul = db.TblYazar.Find(id);
            var yazar = bul.Ad + " " + bul.Soyad;
            
            var açıklama = bul.Açıklama;
            var fotograf = bul.Fotoğraf;
            ViewBag.yzr = yazar;
            ViewBag.acklm = açıklama;
            ViewBag.foto = fotograf;
    



            return View(bul);

        }
    }
}