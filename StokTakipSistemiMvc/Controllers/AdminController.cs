using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StokTakipSistemiMvc.Models.Entity;

namespace StokTakipSistemiMvc.Controllers
{
    public class AdminController : Controller
    {
        DbStokMvcEntities db = new DbStokMvcEntities();
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult YeniAdmin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniAdmin(tbladmin p)
        {
            db.tbladmin.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}