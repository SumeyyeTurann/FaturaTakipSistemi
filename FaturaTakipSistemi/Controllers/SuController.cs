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
    public class SuController : Controller
    {
        ftrTakipEntities db = new ftrTakipEntities();

        // GET: Su
        public ActionResult SFatura()
        {
            //Class1 suf = new Class1();
            //suf.su = db.Su.ToList();
            //return View(suf);

            var aktifkullanıcı = (string)Session["TelefonNo"];
            var üyedegeri = db.kullanici.FirstOrDefault(x => x.TelefonNo == aktifkullanıcı);
            return View(üyedegeri);
        }

        public ActionResult SAbone()
        {
            //Class1 sua = new Class1();
            //sua.su = db.Su.ToList();
            //return View(sua);

            var aktifkullanıcı = (string)Session["TelefonNo"];
            var üyedegeri = db.kullanici.FirstOrDefault(x => x.TelefonNo == aktifkullanıcı);
            return View(üyedegeri);
        }

        [HttpGet]
        public ActionResult YeniSu()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniSu(Su p)
        {
            db.Su.Add(p);
            db.SaveChanges();
            
            return RedirectToAction("SFatura");
        }

        public ActionResult Sil(int id)
        {
            var su = db.Su.Find(id);
            db.Su.Remove(su);
            db.SaveChanges();
            return RedirectToAction("SFatura");
        }

        public ActionResult SuGetir(int SuId)
        {
            var veri = db.Su.Find(SuId);
            return View("SuGetir", veri);
        }

        [HttpGet]
        public ActionResult Düzenle(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Su su = db.Su.Find(id);
            if (su == null)
            {
                return HttpNotFound();
            }
            return View(su);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Düzenle(Su p)
        {
            var veriler = db.Su.Find(p.ID);
            veriler.ID = p.ID;
            veriler.SuId = p.SuId;
            veriler.DagitimFirmasi = p.DagitimFirmasi;
            veriler.HizmetMiktarı = p.HizmetMiktarı;
            veriler.AboneID = p.AboneID;
            veriler.HizmetType = p.HizmetType;    
            veriler.tarih = p.tarih;
            veriler.sontarih = p.sontarih;
            veriler.tutar = p.tutar;
            veriler.odendi = p.odendi;
            db.SaveChanges();
            return RedirectToAction("SFatura");
        }
    }
}