using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class WriterPanelMessageController : Controller
    {
        // GET: WriterPanelMessage
        MessageManager mm = new MessageManager(new EfMessageDal());
        MessageValidator messagevalidator = new MessageValidator();
        public ActionResult Inbox()
        {
            string p = (string)Session["WriterMail"];

            var messagelist = mm.GetListInbox(p);

            return View(messagelist);
        }
        public ActionResult Sendbox()
        {
            string p = (string)Session["WriterMail"];
            var messagelist = mm.GetSendInbox(p);
            return View(messagelist);
        }
        public ActionResult ReadMessage(string p)
        {
            string userEmail = (string)Session["WriterMail"];
            p = userEmail;
            var messagelist = mm.MessageRead(p);
            return View(messagelist);

        }
        public ActionResult NoReadMessage(string p)
        {
            string userEmail = (string)Session["WriterMail"];
            p = userEmail;
            var messagelist = mm.MessageNoRead(p);
            return View(messagelist);
        }
        public PartialViewResult MessageListMenu()
        {
            string userEmail = (string)Session["WriterMail"];      
            var gelen = mm.GetListInbox(userEmail).Count;
            ViewBag.gelen = gelen;
            var giden = mm.GetSendInbox(userEmail).Count;
            ViewBag.giden = giden;
            var okundu = mm.MessageRead(userEmail).Count;
            ViewBag.okundu = okundu;
            var okunmadı = mm.MessageNoRead(userEmail).Count;
            ViewBag.okunmadı = okunmadı;
            return PartialView();
        }
        public ActionResult GetInBoxMessageDetails(int id)
        {
            var values = mm.GetByID(id);
            return View(values);
        }
        public ActionResult Okundu(int id)
        {
            var values = mm.GetByID(id);
            values.MessageRead = true;
            mm.MessageUpdate(values);
            return RedirectToAction("Inbox");
        }
        public ActionResult GetSendBoxMessageDetails(int id)
        {
            var values = mm.GetByID(id);
            return View(values);
        }
        [HttpGet]
        public ActionResult NewMessage()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewMessage(Message p)
        {
            ValidationResult results = messagevalidator.Validate(p);
            if (results.IsValid)
            {
                string mail = (string)Session["WriterMail"];
                p.SenderMail = mail;
                p.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                mm.MessageAdd(p);
                return RedirectToAction("SendBox");
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