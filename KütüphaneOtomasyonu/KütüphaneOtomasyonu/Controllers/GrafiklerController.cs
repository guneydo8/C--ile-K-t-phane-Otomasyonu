using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KütüphaneOtomasyonu.Models;

namespace KütüphaneOtomasyonu.Controllers
{
    public class GrafiklerController : Controller
    {
        // GET: Grafikler
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult VisualizeKitapResult()
        {
            return Json(liste());
        }

        public List<Class1> liste()
        {
            List<Class1> cs = new List<Class1>();
            cs.Add(new Class1()
            {
                yayınevi = "Güneş",
                sayı = 5

            });
            cs.Add(new Class1()
            {
                yayınevi = "Mars",
                sayı = 10
            });
            cs.Add(new Class1()
            {
                yayınevi = "Satürn",
                sayı = 8
            });

            return cs;

        }
    }


}