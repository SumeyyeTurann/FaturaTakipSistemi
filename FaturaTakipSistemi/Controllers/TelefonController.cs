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
    public class TelefonController : Controller
    {
        ftrTakipEntities db = new ftrTakipEntities();


        // GET: Telefon
        public ActionResult Gsm()
        {
            //Class1 cs = new Class1();
            //cs.telefon = db.Telefon.ToList();
            //return View(cs);
            var aktifkullanıcı = (string)Session["TelefonNo"];
            var üyedegeri = db.kullanici.FirstOrDefault(x => x.TelefonNo == aktifkullanıcı);
            return View(üyedegeri);
        }
        public ActionResult FaturaBilgileri()
        {
            //Class1 cb = new Class1();
            //cb.telefon = db.Telefon.ToList();
            //return View(cb);

            var aktifkullanıcı = (string)Session["TelefonNo"];
            var üyedegeri = db.kullanici.FirstOrDefault(x => x.TelefonNo == aktifkullanıcı);
            return View(üyedegeri);
        }

        [HttpGet]
        public ActionResult YeniTelefon()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniTelefon(Telefon p)
        {
            db.Telefon.Add(p);
            db.SaveChanges();
            return RedirectToAction("FaturaBilgileri");
        }

        public ActionResult Sil(int id)
        {
            var tlf = db.Telefon.Find(id);
            db.Telefon.Remove(tlf);
            db.SaveChanges();
            return RedirectToAction("FaturaBilgileri");
        }

        public ActionResult TelefonGetir(int TelefonId)
        {
            var veri = db.Telefon.Find(TelefonId);
            return View("TelefonGetir", veri);
        }

        [HttpGet]
        public ActionResult Guncelle(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Telefon tel = db.Telefon.Find(id);
            if (tel == null)
            {
                return HttpNotFound();
            }
            return View(tel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Guncelle(Telefon p)
        {
            var veriler = db.Telefon.Find(p.ID);
            veriler.ID = p.ID;
            veriler.TelefonId = p.TelefonId;
            veriler.GSMType = p.GSMType;
            veriler.DataMB = p.DataMB;
            veriler.Sms = p.Sms;
            veriler.InternetGB = p.InternetGB;
            veriler.SesDK = p.SesDK;
            veriler.Sabit = p.Sabit;
            veriler.HizmetMiktarı = p.HizmetMiktarı;
            veriler.tarih = p.tarih;
            veriler.sontarih = p.sontarih;
            veriler.tutar = p.tutar;
            veriler.odendi = p.odendi;
            db.SaveChanges();
            return RedirectToAction("FaturaBilgileri");
        }

    }
}