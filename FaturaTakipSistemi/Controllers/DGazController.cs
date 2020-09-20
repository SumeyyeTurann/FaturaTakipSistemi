using FaturaTakipSistemi.Models.Entities;
using FaturaTakipSistemi.Models.Sınıf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace FaturaTakipSistemi.Controllers
{
    public class DGazController : Controller
    {
        ftrTakipEntities db = new ftrTakipEntities();
        // GET: DGaz
        public ActionResult DGAbone()
        {
            //Class1 cs = new Class1();
            //cs.dgaz = db.DGaz.ToList();
            //return View(cs);

            var aktifkullanıcı = (string)Session["TelefonNo"];
            var üyedegeri = db.kullanici.FirstOrDefault(x => x.TelefonNo == aktifkullanıcı);
            return View(üyedegeri);
        }

        public ActionResult DGFatura()
        {
            //Class1 ds = new Class1();
            //ds.dgaz = db.DGaz.ToList();
            //return View(ds);

            var aktifkullanıcı = (string)Session["TelefonNo"];
            var üyedegeri = db.kullanici.FirstOrDefault(x => x.TelefonNo == aktifkullanıcı);
            return View(üyedegeri);
        }

        [HttpGet]
        public ActionResult YeniDGaz()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniDGaz(DGaz p)
        {
            db.DGaz.Add(p);
            db.SaveChanges();
            return RedirectToAction("DGFatura");
        }

        public ActionResult DGazSil(int id)
        {
            var dgaz = db.DGaz.Find(id);
            db.DGaz.Remove(dgaz);
            db.SaveChanges();
            return RedirectToAction("DGFatura");
        }

        public ActionResult DGazGetir(DGaz id)
        {
            var veri = db.DGaz.Find(id);
            return View("DGazGetir", veri);
        }


        [HttpGet]
        public ActionResult Düzenle(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DGaz dg = db.DGaz.Find(id);
            if (dg == null)
            {
                return HttpNotFound();
            }
            return View(dg);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Düzenle(DGaz p)
        {
            var veriler = db.DGaz.Find(p.ID);
            veriler.DGazId = p.DGazId;
            veriler.dagitimfirmasi = p.dagitimfirmasi;
            veriler.HizmetMiktari = p.HizmetMiktari;
            veriler.HizmetType = p.HizmetType;
            veriler.AboneID = p.AboneID;
            veriler.odendi = p.odendi;
            veriler.sontarih = p.sontarih;
            veriler.tarih = p.tarih;
            veriler.tutar = p.tutar;
            db.SaveChanges();
            return RedirectToAction("DGFatura");
        }
    }
}