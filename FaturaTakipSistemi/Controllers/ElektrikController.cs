using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FaturaTakipSistemi.Models.Sınıf;
using FaturaTakipSistemi.Models.Entities;

namespace FaturaTakipSistemi.Controllers
{
    public class ElektrikController : Controller
    {
        private ftrTakipEntities db = new ftrTakipEntities();

        // GET: Elektrik
        public ActionResult EAbone()
        {
            //var elektrik = db.Elektrik.Include(e => e.Abone).Include(e => e.Hizmet).Include(e => e.kullanici);
            //return View(elektrik.ToList());

            var aktifkullanıcı = (string)Session["TelefonNo"];
            var üyedegeri = db.kullanici.FirstOrDefault(x => x.TelefonNo == aktifkullanıcı);
            return View(üyedegeri);
        }

        public ActionResult EFatura()
        {
            var aktifkullanıcı = (string)Session["TelefonNo"];
            var üyedegeri = db.kullanici.FirstOrDefault(x => x.TelefonNo == aktifkullanıcı);
            return View(üyedegeri);
        }

        [HttpGet]
        public ActionResult YeniElektrik()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniElektrik(Elektrik p)
        {
            db.Elektrik.Add(p);
            db.SaveChanges();
            return RedirectToAction("EFatura");
        }

        public ActionResult Sil(int id)
        {
            var elk = db.Elektrik.Find(id);
            db.Elektrik.Remove(elk);
            db.SaveChanges();
            return RedirectToAction("EFatura");
        }

        public ActionResult ElektrikGetir(int ElektrikId)
        {
            var veri = db.Elektrik.Find(ElektrikId);
            return View("ElektrikGetir", veri);
        }

        [HttpGet]
        public ActionResult Düzenle(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Elektrik elektrik = db.Elektrik.Find(id);
            if (elektrik == null)
            {
                return HttpNotFound();
            }
            
            return View(elektrik);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Düzenle(Elektrik p)
        {
            var veriler = db.Elektrik.Find(p.ID);
            veriler.ElektrikId = p.ElektrikId;
            veriler.dagitimfirması = p.dagitimfirması;
            veriler.HizmetMiktari = p.HizmetMiktari;
            veriler.tarih = p.tarih;
            veriler.sontarih = p.sontarih;
            veriler.tutar = p.tutar;
            veriler.odendi = p.odendi;
            db.SaveChanges();
            return RedirectToAction("EFatura");
        }

    }
}
