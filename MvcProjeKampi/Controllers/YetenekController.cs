using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class YetenekController : Controller
    {
        YetenekManager ym = new YetenekManager(new EfYetenekDal());

        // GET: Yetenek
        public ActionResult Index()
        {
            var yetenekvalues = ym.GetYeteneks();
            return View(yetenekvalues);
        }
        public ActionResult YetenekListe()
        {
            var yetenekvalues = ym.GetYeteneks();
            return View(yetenekvalues);
        }
        [HttpGet]
        public ActionResult YetenekEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YetenekEkle(Yetenek p)
        {           
            ym.YetenekAdd(p);
            return RedirectToAction("Index");
        }
        public ActionResult YetenekSil(Yetenek p)
        {
            ym.Delete(p);
            return RedirectToAction("Index");
        }
    }
}