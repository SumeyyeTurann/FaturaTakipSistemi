using FaturaTakipSistemi.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace FaturaTakipSistemi.Controllers
{
    public class LoginController : Controller
    {
        //ftrTakipEntities db = new ftrTakipEntities();
        // GET: Login

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(kullanici p)
        {
            if (ModelState.IsValid)
            {
                using (ftrTakipEntities db = new ftrTakipEntities())
                {
                    var obj = db.kullanici.Where(a => a.TelefonNo.Equals(p.TelefonNo) && a.Password.Equals(p.Password)).FirstOrDefault();
                    if (obj != null)
                    {
                        Session["ID"] = obj.ID.ToString();
                        Session["TelefonNo"] = obj.TelefonNo.ToString();
                        if (Session["TelefonNo"] != null)
                        {
                            return RedirectToAction("Index", "Kullanıcı");
                        }
                        else
                        {
                            return View();
                        }
                    }
                }

            }
            return View(p);
        }


        //var giris = db.kullanici.FirstOrDefault(x => x.telefon == p.telefon && x.Password == p.Password);
        //if (giris != null)
        //{
        //    FormsAuthentication.SetAuthCookie(giris.telefon, false);
        //    Session["telefon"] = giris.telefon.ToString();

        //    //TempData["Ad"] = giris.Ad.ToString();


        //    //if (giris.telefon == "admin@mail.com")
        //    //{
        //    //    return RedirectToAction("Index", "Kullanici");
        //    //}
        //    //return RedirectToAction("Index", "Default");

        //    return RedirectToAction("Index", "Kullanıcı");
        //}
        //else
        //{
        //    return View();
        //}




    }
}