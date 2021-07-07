using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using EntityLayer.Concrete.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class AuthorizationController : Controller
    {
        // GET: Authorization
        AdminManager adminmanager = new AdminManager(new EfAdminDal());
        YetkiManager yetki = new YetkiManager(new EfYetkiDal());
        IAuthService authService = new AuthManager(new AdminManager(new EfAdminDal()), new WriterManager(new EfWriterDal()));

        public ActionResult Index()
        {
            var adminvalues = adminmanager.GetAdmins();
            return View(adminvalues);
        }

        [HttpGet]
        public ActionResult YeniAdmin()
        {
            List<SelectListItem> adminRoleValue = (from x in yetki.GetAll()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.Role,
                                                       Value = x.RoleID.ToString()
                                                   }).ToList();

            ViewBag.adminRoleValue = adminRoleValue;
            return View();
        }
        [HttpPost]
        public ActionResult YeniAdmin(LoginDto loginDto)
        {
            authService.Register(loginDto.AdminUserName, loginDto.AdminPassword);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult AdminDuzenle(int id)
        {
            List<SelectListItem> adminRoleValue = (from x in yetki.GetAll()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.Role,
                                                       Value = x.RoleID.ToString()
                                                   }).ToList();

            ViewBag.adminRoleValue = adminRoleValue;
            var categoryvalue = adminmanager.GetById(id);
            return View(categoryvalue);
        }
        [HttpPost]
        public ActionResult AdminDuzenle(Admin admin)
        {
            adminmanager.Update(admin);
            return RedirectToAction("Index");
        }
    }
}