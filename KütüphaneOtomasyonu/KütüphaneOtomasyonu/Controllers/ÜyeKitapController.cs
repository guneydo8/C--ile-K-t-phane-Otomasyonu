using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KütüphaneOtomasyonu.Models.Entity;

namespace KütüphaneOtomasyonu.Controllers
{
    public class ÜyeKitapController : Controller
    {
        // GET: ÜyeKitap
        MvcKütüphaneEntities db = new MvcKütüphaneEntities();
        public ActionResult Index(Tblİşlemler t)
        {

            var kullanıcı = (string)Session["mail"].ToString();
            var üye = db.TblÜyeler.Where(x => x.Mail == kullanıcı).Select(z => z.Id).FirstOrDefault();

            var liste = db.Tblİşlemler.Where(x => x.Üye == üye).ToList();
          

            return View(liste);
        }
    }
}