using MvcCv.Models.Entity;
using MvcCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    public class SertifikaController : Controller
    {
        // GET: Sertifika

        GenericRepositories<TblCertificate> repo = new GenericRepositories<TblCertificate>();
        public ActionResult Index()
        {
            var sertifika = repo.List();

            return View(sertifika);
        }

        [HttpGet]
        public ActionResult SertifikaGetir(int id)
        {
            var sertifika = repo.Find(x => x.ID == id);
            return View(sertifika);
        }
        [HttpPost]
        public ActionResult SertifikaGetir(TblCertificate p)

        {
            var sertifika = repo.Find(x => x.ID == p.ID);
            sertifika.Aciklama = p.Aciklama;
            sertifika.Tarih = p.Tarih;
            repo.TUpdate(sertifika);
            return RedirectToAction("Index");
        }
       

        [HttpGet]
        public ActionResult yenisertifika()
        {
            return View();
        }

        [HttpPost]
        public ActionResult yenisertifika(TblCertificate p)
        {
            repo.TAdd(p);
            return RedirectToAction("Index");
        }

        public ActionResult SertifikaSil(int id) 
        {
            var sertifika = repo.Find(x => x.ID == id);
            repo.TDelete (sertifika);
            return RedirectToAction("Index");
        }

    }
}