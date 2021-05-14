using DataAccessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class istatistikController : Controller
    {
        Context c = new Context();
        public ActionResult Index()
        {
            var deger1 = c.Categories.Count().ToString();
            ViewBag.d1 = deger1;
            var deger2 = c.Headings.Count(x => x.HeadingName == "Yazılım").ToString();
            ViewBag.d2 = deger2;
            var deger3 = c.Writers.Count(x => x.WriterName.Contains("a"));
            ViewBag.d3 = deger3;
            var deger4 = c.Headings.Max(x => x.Category.CategoryName);
            ViewBag.d4 = deger4;
            var deger5 = c.Categories.Count(x => x.CategoryStatus == true);
            ViewBag.d5 = deger5;
            var deger6 = c.Categories.Count(x => x.CategoryStatus == false);
            ViewBag.d6 = deger6;
            var deger7 = Convert.ToInt16(deger5) - Convert.ToInt16(deger6);
            ViewBag.d7 = deger7;
            var deger8 = c.Writers.Count().ToString();
            ViewBag.d8 = deger8;
            return View();

        }
    }
}