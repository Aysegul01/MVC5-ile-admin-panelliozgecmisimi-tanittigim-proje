using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCv.Models.Entity;
using MvcCv.Repositories;
namespace MvcCv.Controllers
{
    public class EgitimController : Controller
    {
        // GET: Egitim
        GenericRepositories<TblEducation> repo = new GenericRepositories<TblEducation>();
        public ActionResult Index()
        {
            var egitim = repo.List();
            return View(egitim);
        }
        [HttpGet]
        public ActionResult EgitimEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult EgitimEkle(TblEducation p)
        { if (!ModelState.IsValid) 
            {
                return View("EgitimEkle");
            }
            repo.TAdd(p);
            return RedirectToAction("Index");
        }

        public ActionResult EgitimSil(int id)
        {
            TblEducation t = repo.Find(x => x.ID == id);
            repo.TDelete(t);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EgitimDuzenle(int id)
        {
            TblEducation t = repo.Find(x => x.ID == id);
            return View(t);
        }

        [HttpPost]
        public ActionResult EgitimDuzenle(TblEducation p)
        {
            if (!ModelState.IsValid)
            {
                return View("EgitimDuzenle");
            }
            TblEducation t = repo.Find(x => x.ID == p.ID);
            t.Baslik = p.Baslik;
            t.Altbaslik1 = p.Altbaslik1;
            t.Altbaslik2 = p.Altbaslik2;
            t.GNO = p.GNO;
            t.Tarih = p.Tarih;
            repo.TUpdate(t);
            return RedirectToAction("Index");
        }
    }
}