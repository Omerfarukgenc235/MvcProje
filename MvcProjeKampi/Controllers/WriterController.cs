using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class WriterController : Controller
    {
        WriterManager wm = new WriterManager(new EfWriterDal());
        WriterValidator writervalidator = new WriterValidator();
        public ActionResult Index()
        {
            var WriterValues = wm.GetList();
            return View(WriterValues);
        }
        [HttpGet]
        public ActionResult AddWriter()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddWriter(Writer p)
        {
            ValidationResult results = writervalidator.Validate(p);
            if(results.IsValid)
            {
                if (Request.Files.Count > 0)
                {
                    string dosyaadi = Path.GetFileName(Request.Files[0].FileName);
                    string uzanti = Path.GetExtension(Request.Files[0].FileName);
                    string yol = "~/Image/" + dosyaadi + uzanti;
                    Request.Files[0].SaveAs(Server.MapPath(yol));
                    p.WriterImage = "/Image/" + dosyaadi + uzanti;
                }
                wm.WriterAdd(p);
                return RedirectToAction("Index");
            }
            else
            {
                foreach(var x in results.Errors)
                {
                    ModelState.AddModelError(x.PropertyName,x.ErrorMessage);
                }
            }
            return View();
        }
        [HttpGet]
        public ActionResult EditWriter(int id)
        {
            var writervalue = wm.GetByID(id);
            return View(writervalue);
        }
        [HttpPost]
        public ActionResult EditWriter(Writer p)     
        {
            ValidationResult results = writervalidator.Validate(p);
            if (results.IsValid)
            {
                if (Request.Files.Count > 0)
                {
                    string dosyaadi = Path.GetFileName(Request.Files[0].FileName);
                    string uzanti = Path.GetExtension(Request.Files[0].FileName);
                    string yol = "~/Image/" + dosyaadi + uzanti;
                    Request.Files[0].SaveAs(Server.MapPath(yol));
                    p.WriterImage = "/Image/" + dosyaadi + uzanti;
                }
                wm.WriterUpdate(p);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var x in results.Errors)
                {
                    ModelState.AddModelError(x.PropertyName, x.ErrorMessage);
                }
            }
            return View();
        }
    }
}