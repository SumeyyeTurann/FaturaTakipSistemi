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
    public class InternetsController : Controller
    {
        private ftrTakipEntities db = new ftrTakipEntities();

        // GET: Internets
        public ActionResult Index()
        {
            var internet = db.Internet.Include(i => i.Abone).Include(i => i.Hizmet).Include(i => i.kullanici);
            return View(internet.ToList());
        }

        // GET: Internets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Internet internet = db.Internet.Find(id);
            if (internet == null)
            {
                return HttpNotFound();
            }
            return View(internet);
        }

        // GET: Internets/Create
        public ActionResult Create()
        {
            ViewBag.AboneID = new SelectList(db.Abone, "AboneID", "AboneNo");
            ViewBag.HizmetType = new SelectList(db.Hizmet, "HizmetID", "HizmetType");
            ViewBag.InternetId = new SelectList(db.kullanici, "ID", "Ad");
            return View();
        }

        // POST: Internets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,tarih,sontarih,tutar,odendi,HizmetMiktari,InternetId,HizmetType,AboneID")] Internet internet)
        {
            if (ModelState.IsValid)
            {
                db.Internet.Add(internet);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AboneID = new SelectList(db.Abone, "AboneID", "AboneNo", internet.AboneID);
            ViewBag.HizmetType = new SelectList(db.Hizmet, "HizmetID", "HizmetType", internet.HizmetType);
            ViewBag.InternetId = new SelectList(db.kullanici, "ID", "Ad", internet.InternetId);
            return View(internet);
        }

        // GET: Internets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Internet internet = db.Internet.Find(id);
            if (internet == null)
            {
                return HttpNotFound();
            }
            ViewBag.AboneID = new SelectList(db.Abone, "AboneID", "AboneNo", internet.AboneID);
            ViewBag.HizmetType = new SelectList(db.Hizmet, "HizmetID", "HizmetType", internet.HizmetType);
            ViewBag.InternetId = new SelectList(db.kullanici, "ID", "Ad", internet.InternetId);
            return View(internet);
        }

        // POST: Internets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,tarih,sontarih,tutar,odendi,HizmetMiktari,InternetId,HizmetType,AboneID")] Internet internet)
        {
            if (ModelState.IsValid)
            {
                db.Entry(internet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AboneID = new SelectList(db.Abone, "AboneID", "AboneNo", internet.AboneID);
            ViewBag.HizmetType = new SelectList(db.Hizmet, "HizmetID", "HizmetType", internet.HizmetType);
            ViewBag.InternetId = new SelectList(db.kullanici, "ID", "Ad", internet.InternetId);
            return View(internet);
        }

        // GET: Internets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Internet internet = db.Internet.Find(id);
            if (internet == null)
            {
                return HttpNotFound();
            }
            return View(internet);
        }

        // POST: Internets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Internet internet = db.Internet.Find(id);
            db.Internet.Remove(internet);
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
