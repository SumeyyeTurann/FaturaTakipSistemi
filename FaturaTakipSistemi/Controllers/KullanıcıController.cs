using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FaturaTakipSistemi.Models.Entities;

namespace FaturaTakipSistemi.Controllers
{
    public class KullanıcıController : Controller
    {
        private ftrTakipEntities db = new ftrTakipEntities();

        // GET: Kullanıcı
        public ActionResult Index()
        {
            var aktifkullanıcı = (string)Session["ID"];
            var üyedegeri = db.kullanici.FirstOrDefault(x => x.ID == aktifkullanıcı);
            return View(üyedegeri);
        }

        // GET: Kullanıcı/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            kullanici kullanici = db.kullanici.Find(id);
            if (kullanici == null)
            {
                return HttpNotFound();
            }
            return View(kullanici);
        }

        // GET: Kullanıcı/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Kullanıcı/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Ad,Soyad,Adres,Mail,Password,TelefonNo")] kullanici kullanici)
        {
            if (ModelState.IsValid)
            {
                db.kullanici.Add(kullanici);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(kullanici);
        }

        // GET: Kullanıcı/Edit/5
        //biz bunu yapmaya çalışıyoruz uyarla projene
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            kullanici kullanici = db.kullanici.Find(id);
            if (kullanici == null)
            {
                return HttpNotFound();
            }
            return View(kullanici);
        }

        // POST: Kullanıcı/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Ad,Soyad,Adres,Mail,Password,TelefonNo")] kullanici kullanici)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kullanici).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(kullanici);
        }

        // GET: Kullanıcı/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            kullanici kullanici = db.kullanici.Find(id);
            if (kullanici == null)
            {
                return HttpNotFound();
            }
            return View(kullanici);
        }

        // POST: Kullanıcı/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            kullanici kullanici = db.kullanici.Find(id);
            db.kullanici.Remove(kullanici);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
