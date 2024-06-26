﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StokTakipSistemiMvc.Models.Entity;

namespace StokTakipSistemiMvc.Controllers
{
    public class SatislarController : Controller
    {
        DbStokMvcEntities db = new DbStokMvcEntities();
        public ActionResult Index()
        {
            var satislar = db.tblsatislar.ToList();
            return View(satislar);
        }

        [HttpGet]
        public ActionResult YeniSatis()
        {
            //ürünler
            List<SelectListItem> urun = (from x in db.tblurunler.ToList()
                                         select new SelectListItem
                                         {
                                             Text = x.ad,
                                             Value = x.id.ToString()
                                         }).ToList();
            ViewBag.drop1 = urun;

            //Personel
            List<SelectListItem> per = (from x in db.tblpersonel.ToList()
                                        select new SelectListItem
                                        {
                                            Text = x.ad + " " + x.soyad,
                                            Value = x.id.ToString()
                                        }).ToList();
            ViewBag.drop2 = per;

            //Müşteriler
            List<SelectListItem> must = (from x in db.tblkmusteri.ToList()
                                         select new SelectListItem
                                         {
                                             Text = x.ad + " " + x.soyad,
                                             Value = x.id.ToString()
                                         }).ToList();
            ViewBag.drop3 = must;
            return View();

        }

        [HttpPost]
        public ActionResult YeniSatis(tblsatislar p)
        {
            var urun = db.tblurunler.Where(x => x.id == p.tblurunler.id).FirstOrDefault();
            var musteri = db.tblkmusteri.Where(x => x.id == p.tblkmusteri.id).FirstOrDefault();
            var personel = db.tblpersonel.Where(x => x.id == p.tblpersonel.id).FirstOrDefault();
            p.tblurunler = urun;
            p.tblkmusteri = musteri;
            p.tblpersonel = personel;
            p.tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            db.tblsatislar.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}