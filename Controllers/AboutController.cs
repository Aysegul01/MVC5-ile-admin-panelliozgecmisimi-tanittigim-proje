using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCv.Models.Entity;
using MvcCv.Repositories;

namespace MvcCv.Controllers
{
    public class AboutController : Controller
    {
        // GET: About
        GenericRepositories<TblAbout> repo = new GenericRepositories<TblAbout>();
        [HttpGet]
        public ActionResult Index()
        {
            var hakkımda = repo.List();
            return View(hakkımda);
        }
            
           
            [HttpPost]
            public ActionResult Index(TblAbout p)
            {
                var t = repo.Find(x => x.ID == 1);
                t.Ad = p.Ad;
                t.Soyad = p.Soyad;
                t.Adres = p.Adres;
                t.Resim= p.Resim;
                t.Telefon = p.Telefon;
                t.Mail = p.Mail;
                t.Açıklama = p.Açıklama;
                repo.TUpdate(t);
                return RedirectToAction("Index");
            }
        
    }
}