using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KütüphaneOtomasyonu.Models.Entity;
using KütüphaneOtomasyonu.Models.Sınıf;

namespace KütüphaneOtomasyonu.Controllers
{

    [AllowAnonymous]
    public class VitrinController : Controller
    {
        // GET: Vitrin
        MvcKütüphaneEntities db = new MvcKütüphaneEntities();

        
        public ActionResult Index()
        {
            Class1 baglantı = new Class1();
            baglantı.ktk = db.TblKitaplar.ToList();
            baglantı.hk = db.TblHakkımızda.ToList();

           

           

            
            return View(baglantı);
        }

    
      

      [HttpPost]
      public ActionResult Index(Tblİletişim x)
        {
            db.Tblİletişim.Add(x);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

       
    }
}