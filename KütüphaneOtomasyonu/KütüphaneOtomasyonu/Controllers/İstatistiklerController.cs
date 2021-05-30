using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using KütüphaneOtomasyonu.Models.Entity;

namespace KütüphaneOtomasyonu.Controllers
{
    public class İstatistiklerController : Controller
    {
        // GET: İstatistikler

        MvcKütüphaneEntities db = new MvcKütüphaneEntities();

        public ActionResult Index()
        {
            var kasa = db.TblCezalar.Sum(x => x.Para);
            ViewBag.k = kasa;
            var toplamüye = db.TblÜyeler.Count();
            ViewBag.üye = toplamüye;
            var kitapsayısı = db.TblKitaplar.Count();
            ViewBag.kitap = kitapsayısı;
            var aktifişlem = db.Tblİşlemler.Where(x => x.Durum == false).Count();
            ViewBag.aktif = aktifişlem;
            
            return View();
        }

        public ActionResult Hava()
        {
            return View();

        }

        public ActionResult Galeri()
        {
            return View();
        }

        public ActionResult ResimYükle(HttpPostedFileBase dosya)
        {
            if(dosya.ContentLength > 0)
            {
                string dosyayoolu = Path.Combine(Server.MapPath("/Vitrin/Resimler/"), Path.GetFileName(dosya.FileName));
                dosya.SaveAs(dosyayoolu);

            }
            return RedirectToAction("Galeri");

        }

        public ActionResult LinqKartlar()
        {
            var personel = db.TblPersonel.Count();
            ViewBag.deger1 = personel;
            var aktifüye = db.TblÜyeler.Where(x => x.Durum == false).Count();
            ViewBag.deger2 = aktifüye;
            var pasifüye = db.TblÜyeler.Where(x => x.Durum == true).Count();
            ViewBag.deger3 = pasifüye;
            var yazar = db.TblYazar.Count();
            ViewBag.deger4 = yazar;
            var kategori = db.TblKategoriler.Count();
            ViewBag.deger5 = kategori;
            var mesaj = db.Tblİletişim.Count();
            ViewBag.deger6 = mesaj;
            var yazar2 = db.maxkitaplıyazar().FirstOrDefault();
            ViewBag.deger7 = yazar2;
            var yayınevi = db.TblKitaplar.GroupBy(x => x.YayınEvi).OrderByDescending(y => y.Count()).Select(z => new { z.Key }).FirstOrDefault();
            ViewBag.deger8 = yayınevi;
            var işlem = db.Tblİşlemler.Where(x => x.AlışTarihi == DateTime.Today).Select(x => x.AlışTarihi).Count();
            ViewBag.deger9 = işlem;
            var personel2 = db.enbasarılıpersonel().FirstOrDefault();
            ViewBag.deger10 = personel2;
            var üye = db.enaktifüye().FirstOrDefault();
            ViewBag.deger11 = üye;
            var kitap = db.encokokunankitap().FirstOrDefault();
            ViewBag.deger12 = kitap;









            return View();

        }
    }
}