using FaturaTakipSistemi.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FaturaTakipSistemi.Controllers
{
    public class DefaultController : Controller
    {
        ftrTakipEntities db = new ftrTakipEntities();
        // GET: Default
        public ActionResult Index()
        {
            //Class1 cs = new Class1();
            //cs.Deger1 = db.tblAbout.ToList();
            //cs.Deger2 = db.tblExperıence.ToList();
            //cs.Deger3 = db.tblEducatıon.ToList();
            //cs.Deger4 = db.tblSkılls.ToList();
            //cs.Deger5 = db.tblInterests.ToList();
            //cs.Deger6 = db.tblArticles.ToList();

            //return View(cs);
            var aktifkullanıcı = (string)Session["ID"];
            var üyedegeri = db.kullanici.FirstOrDefault(x => x.ID == aktifkullanıcı);
            return View(üyedegeri);
        }
       
    }
}