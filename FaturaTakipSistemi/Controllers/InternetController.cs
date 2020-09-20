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
    public class InternetController : Controller
    {
        ftrTakipEntities db = new ftrTakipEntities();
        // GET: Internet
        public ActionResult IAbone()
        {
            //Class1 cs = new Class1();
            //cs.internet = db.Internet.ToList();
            //return View(cs);

            var aktifkullanıcı = (string)Session["TelefonNo"];
            var üyedegeri = db.kullanici.FirstOrDefault(x => x.TelefonNo == aktifkullanıcı);
            return View(üyedegeri);
        }

        public ActionResult IFatura()
        {
            //Class1 ds = new Class1();
            //ds.internet = db.Internet.ToList();
            //return View(ds);

            var aktifkullanıcı = (string)Session["TelefonNo"];
            var üyedegeri = db.kullanici.FirstOrDefault(x => x.TelefonNo == aktifkullanıcı);
            return View(üyedegeri);
        }

        [HttpGet]
        public ActionResult YeniInternet()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniInternet(Internet p)
        {
            db.Internet.Add(p);
            db.SaveChanges();
            return RedirectToAction("IFatura");
        }

        public ActionResult Sil(int id)
        {
            var inter = db.Internet.Find(id);
            db.Internet.Remove(inter);
            db.SaveChanges();
            return RedirectToAction("IFatura");
        }

        public ActionResult InternetGetir(int InternetId)
        {
            var veri = db.Internet.Find(InternetId);
            return View("InternetGetir", veri);
        }

        [HttpGet]
        public ActionResult Düzenle(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Internet ınt = db.Internet.Find(id);
            if (ınt == null)
            {
                return HttpNotFound();
            }
            return View(ınt);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Düzenle(Internet p)
        {
            var veriler = db.Internet.Find(p.ID);
            veriler.InternetId = p.InternetId;
            veriler.HizmetMiktari = p.HizmetMiktari;
            veriler.tarih = p.tarih;
            veriler.sontarih = p.sontarih;
            veriler.tutar = p.tutar;
            veriler.odendi = p.odendi;
            db.SaveChanges();
            return RedirectToAction("IFatura");
        }

    }
}