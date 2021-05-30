using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KütüphaneOtomasyonu.Models.Entity;

namespace KütüphaneOtomasyonu.Controllers
{
    public class KitaplarController : Controller
    {
        MvcKütüphaneEntities db = new MvcKütüphaneEntities();
        // GET: Kitaplar
        public ActionResult Index(string x)
        {
            //var liste = db.TblKitaplar.ToList();
            var liste = from k in db.TblKitaplar select k;
            if (!string.IsNullOrEmpty(x))
            {
                liste = liste.Where(y => y.Ad.Contains(x));
            }
          
            
            return View(liste.ToList());
        }

        [HttpGet]
        public ActionResult Ekle()
        {
            List<SelectListItem> kategori = (from x in db.TblKategoriler
                                             select new SelectListItem
                                             {
                                                 Text = x.KategoriAd,
                                                 Value = x.Id.ToString()
                                             }).ToList();
            ViewBag.ktgr = kategori;

            List<SelectListItem> yazar = (from x in db.TblYazar
                                             select new SelectListItem
                                             {
                                                 Text = x.Ad+" "+x.Soyad,
                                                 Value = x.Id.ToString()
                                             }).ToList();
            ViewBag.yzr = yazar;


            return View();
        }

        [HttpPost]
        public ActionResult Ekle(TblKitaplar x)
        {
            var kategori = db.TblKategoriler.Where(k => k.Id == x.TblKategoriler.Id).FirstOrDefault();
            x.TblKategoriler = kategori;
            var yazar = db.TblYazar.Where(y => y.Id == x.TblYazar.Id).FirstOrDefault();
            x.TblYazar = yazar;
          


          
            x.Durum = true;
            db.TblKitaplar.Add(x);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Sil(int id)
        {
            var rmv = db.TblKitaplar.Find(id);
            db.TblKitaplar.Remove(rmv);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Güncelle(int id)
        {
            var bul = db.TblKitaplar.Find(id);
            List<SelectListItem> kategori = (from x in db.TblKategoriler
                                             select new SelectListItem
                                             {
                                                 Text = x.KategoriAd,
                                                 Value = x.Id.ToString()
                                             }).ToList();
            ViewBag.ktgr = kategori;

            List<SelectListItem> yazar = (from x in db.TblYazar
                                          select new SelectListItem
                                          {
                                              Text = x.Ad + " " + x.Soyad,
                                              Value = x.Id.ToString()
                                          }).ToList();
            ViewBag.yzr = yazar;
            return View(bul);
        }

        public ActionResult Güncelle2(TblKitaplar x)
        {
            var güncelle = db.TblKitaplar.Find(x.Id);
            güncelle.Ad = x.Ad;
            güncelle.BasımYılı = x.BasımYılı;
            güncelle.Durum = x.Durum;
            güncelle.SayfaSayısı = x.SayfaSayısı;
            güncelle.YayınEvi = x.YayınEvi;
            var kategori = db.TblKategoriler.Where(y => y.Id == x.TblKategoriler.Id).FirstOrDefault();
            güncelle.Kategori = kategori.Id;
            var yazar = db.TblYazar.Where(z => z.Id == x.TblYazar.Id).FirstOrDefault();
            güncelle.Yazar = yazar.Id;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}