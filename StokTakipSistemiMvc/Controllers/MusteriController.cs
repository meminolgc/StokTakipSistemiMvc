using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StokTakipSistemiMvc.Models.Entity;
using StokTakipSistemiMvc.Controllers;
using PagedList;
using PagedList.Mvc;

namespace StokTakipSistemiMvc.Controllers
{

    public class MusteriController : Controller
    {
        DbStokMvcEntities db = new DbStokMvcEntities();

        [Authorize]
        public ActionResult Index(int sayfa = 1)
        {
            var musteriListe = db.tblkmusteri.Where(x => x.durum == true).ToList().ToPagedList(sayfa, 10);
            return View(musteriListe);
        }

        [HttpGet]
        public ActionResult YeniMusteri()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniMusteri(tblkmusteri p)
        {
            if (!ModelState.IsValid)
            {
                return View("YeniMusteri");
            }
            p.durum = true;
            db.tblkmusteri.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult MusteriSil(tblkmusteri p)
        {
            var musteriBul = db.tblkmusteri.Find(p.id);
            musteriBul.durum = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult MusteriGetir(int id)
        {
            var mus = db.tblkmusteri.Find(id);
            return View("MusteriGetir", mus);
        }

        public ActionResult MusteriGuncelle(tblkmusteri t)
        {
            var mus = db.tblkmusteri.Find(t.id);
            mus.ad = t.ad;
            mus.soyad = t.soyad;
            mus.sehir = t.sehir;
            mus.bakiye = t.bakiye;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }

}