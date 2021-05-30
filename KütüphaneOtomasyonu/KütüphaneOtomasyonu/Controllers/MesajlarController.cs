using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KütüphaneOtomasyonu.Models.Entity;

namespace KütüphaneOtomasyonu.Controllers
{
    [Authorize]
    public class MesajlarController : Controller
    {
        MvcKütüphaneEntities db = new MvcKütüphaneEntities();
        // GET: Mesajlar

        
        public ActionResult Liste()
        {
            var mail = (string)Session["Mail"].ToString();
            var liste = db.TblMesajlar.Where(x => x.Alıcı == mail).ToList();

            return View(liste);
        }

        
        [HttpGet]
        public ActionResult YeniMesaj(string mail)
        {
            var bul = db.TblMesajlar.Find(mail);
            return View(bul);
        }


        [HttpPost]
        public ActionResult YeniMesaj(TblMesajlar x)
        {
            x.Gönderen = Session["Mail"].ToString();
            x.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            db.TblMesajlar.Add(x);
            db.SaveChanges();

            return RedirectToAction("GidenKutusu");
        }

        
        public ActionResult GidenKutusu()
        {
            var mail = (string)Session["mail"].ToString();
            var liste = db.TblMesajlar.Where(x => x.Gönderen == mail).ToList();

            return View(liste);
        }

        public PartialViewResult partial1()
        {

            var bul = Session["Mail"].ToString();
            var gelen = db.TblMesajlar.Where(x => x.Alıcı == bul).Count();
            ViewBag.d1 = gelen;
            var giden = db.TblMesajlar.Where(x => x.Gönderen == bul).Count();
            ViewBag.d2 = giden;
            return PartialView();
        }
    }
}