using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StokTakipSistemiMvc.Models.Entity;

namespace StokTakipSistemiMvc.Controllers
{
    public class UrunController : Controller
    {
        DbStokMvcEntities db = new DbStokMvcEntities();

        public ActionResult Index()
        {
            var urunler = db.tblurunler.ToList();
            return View(urunler);
        }

        [HttpGet]
        public ActionResult YeniUrun()
        {
            List<SelectListItem> ktg = (from x in db.tblkategori.ToList()
                                        select new SelectListItem
                                        {
                                            Text = x.ad,
                                            Value = x.id.ToString()
                                        }).ToList();
            ViewBag.drop = ktg;
            return View();
        }

        [HttpPost]
        public ActionResult YeniUrun(tblurunler t)
        {
            var ktgr = db.tblkategori.Where(x => x.id == t.tblkategori.id).FirstOrDefault();
            t.tblkategori = ktgr;
            db.tblurunler.Add(t);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult UrunGetir(int id)
        {
            var ktg = db.tblurunler.Find(id);
            return View("UrunGetir", ktg);
        }

        //!!
        public ActionResult UrunSil(int id)
        {
            var sil = db.tblurunler.Find(id);
            db.tblurunler.Remove(sil);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}