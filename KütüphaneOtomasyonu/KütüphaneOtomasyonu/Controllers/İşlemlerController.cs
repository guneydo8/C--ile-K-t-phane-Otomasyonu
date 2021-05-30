using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KütüphaneOtomasyonu.Models.Entity;

namespace KütüphaneOtomasyonu.Controllers
{
    public class İşlemlerController : Controller
    {
        MvcKütüphaneEntities db = new MvcKütüphaneEntities();
        // GET: İşlemler
        public ActionResult Index()
        {
            var liste = db.Tblİşlemler.Where(x => x.Durum == true).ToList();
            return View(liste);
        }
    }
}