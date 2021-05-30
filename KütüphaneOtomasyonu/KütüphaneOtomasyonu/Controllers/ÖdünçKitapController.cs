using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KütüphaneOtomasyonu.Models.Entity;

namespace KütüphaneOtomasyonu.Controllers
{
    public class ÖdünçKitapController : Controller
    {
        // GET: ÖdünçKitap
        MvcKütüphaneEntities db = new MvcKütüphaneEntities();
        public ActionResult Index()
        {
            var liste = db.Tblİşlemler.Where(x=>x.Durum==false).ToList();
            return View(liste);
        }
        [HttpGet]
        public ActionResult Ödünç()
        {
            List<SelectListItem> üye = (from x in db.TblÜyeler.Where(k=>k.Durum==true)
                                        select new SelectListItem
                                        {
                                            Text = x.Ad + " " + x.Soyad,
                                            Value = x.Id.ToString()
                                        }).ToList();
            ViewBag.deger1 = üye;

            List<SelectListItem> kitap = (from x in db.TblKitaplar.Where(k=>k.Durum==true)
                                          select new SelectListItem
                                          {
                                              Text = x.Ad,
                                              Value = x.Id.ToString()
                                          }).ToList();
            ViewBag.deger2 = kitap;

            List<SelectListItem> personel = (from x in db.TblPersonel
                                             select new SelectListItem
                                             {
                                                 Text = x.AdSoyad,
                                                 Value = x.Id.ToString()
                                             }).ToList();
            ViewBag.deger3 = personel;
          
            return View();

        }

        [HttpPost]
        public ActionResult Ödünç(Tblİşlemler x)
        {
            var üye = db.TblÜyeler.Where(y => y.Id == x.TblÜyeler.Id).FirstOrDefault();
            x.TblÜyeler = üye;
            var kitap = db.TblKitaplar.Where(y => y.Id == x.TblKitaplar.Id).FirstOrDefault();
            x.TblKitaplar = kitap;
            var personel = db.TblPersonel.Where(y => y.Id == x.TblPersonel.Id).FirstOrDefault();
            x.TblPersonel = personel;
            x.AlışTarihi = DateTime.Parse(DateTime.Now.ToShortDateString());
            x.TeslimTarihi = DateTime.Now.AddDays(15);
            x.TblKitaplar.Durum = false;
            x.TblÜyeler.Durum = false;
            x.Durum = false;
            db.Tblİşlemler.Add(x);
           
            db.SaveChanges();


            return RedirectToAction("Index");
        }

      
        public ActionResult Kitapİade(Tblİşlemler x)
        {
            var bul = db.Tblİşlemler.Find(x.Id);
            DateTime t1 = DateTime.Parse(bul.TeslimTarihi.ToString());
            DateTime t2 = DateTime.Parse(DateTime.Now.ToShortDateString());



            TimeSpan t3 = (t2 - t1);


            ViewBag.ceza = t3.TotalDays.ToString();

            return View(bul);
        }

        public ActionResult Güncelle(Tblİşlemler x)
        {
            var güncelle = db.Tblİşlemler.Find(x.Id);
            güncelle.İadeTarihi = x.İadeTarihi;
            x.TblÜyeler.Durum = true;
            x.TblKitaplar.Durum = true;
            x.Durum = true;
            güncelle.Durum = x.Durum;
            güncelle.TblÜyeler.Durum = x.TblÜyeler.Durum;
            güncelle.TblKitaplar.Durum = x.TblKitaplar.Durum;

            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}