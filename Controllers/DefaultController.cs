using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCv.Models.Entity;
namespace MvcCv.Controllers {
[AllowAnonymous]
 public class DefaultController : Controller
    {
        // GET: Default
        DbCVEntities db = new DbCVEntities();
        public ActionResult Index()
        {
            var degerler = db.TblAbout.ToList();
            return View(degerler);
        }

        public PartialViewResult SosyalMedya()
        {
            var SosyalMedya = db.TblSosyalMedya.Where(x=>x.Durum==true).ToList();
            return PartialView(SosyalMedya);
        }
        public PartialViewResult Experıence()
        {
            var Experıence = db.TblExperıence.ToList();
            return PartialView(Experıence);
        }

        public PartialViewResult Education()
        {
            var Education = db.TblEducation.ToList();
            return PartialView(Education);
        }

        public PartialViewResult Talent()
        {
            var Talent = db.TblTalent.ToList();
            return PartialView(Talent);
        }
        public PartialViewResult Hobby()
        {
            var Hobby = db.TblHobby.ToList();
            return PartialView(Hobby);
        }

        public PartialViewResult Certificate()
        {
            var Certificate = db.TblCertificate.ToList();
            return PartialView(Certificate);
        }
        
        [HttpGet]
        public PartialViewResult Contact()
        {
            var Contact = db.TblContact.ToList();
            return PartialView(Contact);
        }
        [HttpPost]
        public PartialViewResult Contact(TblContact t)
        {
            t.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            db.TblContact.Add(t);
            db.SaveChanges();
            return PartialView();
        }
    }
}