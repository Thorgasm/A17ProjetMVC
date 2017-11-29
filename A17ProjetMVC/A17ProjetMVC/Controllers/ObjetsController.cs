using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using A17ProjetMVC.DAL;
using A17ProjetMVC.Models;
using Microsoft.AspNet.Identity;

namespace A17ProjetMVC.Controllers
{
    [RoutePrefix("Objets")]
    public class ObjetsController : Controller
    {
        private UnitOfWork unitOfWork = new UnitOfWork();

        
        [Route("~/")]
        [Route("~/Index")]
        [Route("Index")]
        public ActionResult Index()
        {

            List<Categorie> lstCats = unitOfWork.CategorieRepository.Get().ToList();
            IEnumerable<SelectListItem> cats = new SelectList(lstCats, "CategorieID", "Nom");

            string cat;
            if (Request["CategorieID"] != null)
            cat = Request["CategorieID"].ToString();
            else cat = "1";

            ViewBag.Categories = cats;
            return View(unitOfWork.ObjetRepository.GetObjetsByCat(unitOfWork.ObjetRepository,int.Parse(cat)));
        }
        [HttpPost]
        public ActionResult Index(FormCollection form)
        {

            List<Categorie> lstCats = unitOfWork.CategorieRepository.Get().ToList();
            IEnumerable<SelectListItem> cats = new SelectList(lstCats, "CategorieID", "Nom");

            string cat;
            if (form["CategorieID"] != null)
                cat = Request["CategorieID"].ToString();
            else cat = "1";

            ViewBag.Categories = cats;
            return View(unitOfWork.ObjetRepository.GetObjetsByCat(unitOfWork.ObjetRepository,int.Parse(cat)));
        }
        [Route("ObjetsDispo")]
        public ActionResult ObjetsDispo()
        {


            return View(unitOfWork.Repo<Objet>().GetAvailableObjets());
        }
        [Route("MesObjets")]
        public ActionResult MyObjects()
        {
            return View(unitOfWork.Repo<Objet>().GetMyObjects());
        }
        [Route("TopObjets")]
        public ActionResult Top5Objets()
        {
            return View(unitOfWork.Repo<Objet>().getTop5Objets());
        }
        [Route("TopMembres")]
        public ActionResult TopMembres()
        {
            return View(unitOfWork.Repo<Objet>().getTopMembres());
        }

        [Route("Emprunt")]
        public ActionResult Emprunt(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Objet objet = unitOfWork.ObjetRepository.GetByID(id);
            if (objet == null)
            {
                return HttpNotFound();
            }
            EmpruntVM e = new EmpruntVM();
            e.ObjetID = objet.ObjetID;
            ViewBag.Objet = objet.nomObjet;

            return View(e);
        }

        
        [HttpPost]
        public ActionResult Emprunt(FormCollection form)
        {
            if (ModelState.IsValid)
            {
                string id = form["objetID"].ToString();
                Emprunt e = new Emprunt(1, int.Parse(id));
                e.dateDebut = DateTime.Now;
                string a = form["nbJours"].ToString();
                e.dateFin = DateTime.Now.AddDays(int.Parse(a));

                unitOfWork.EmpruntRepository.Insert(e);
                unitOfWork.Save();
                return RedirectToAction("Index");
            }

            return View();
        }



        [Route("Details")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Objet objet = unitOfWork.ObjetRepository.GetByID(id);
            if (objet == null)
            {
                return HttpNotFound();
            }
            return View(objet);
        }

        [Route("Create")]
        public ActionResult Create()
        {
            List<Categorie> lstCats = unitOfWork.CategorieRepository.Get().ToList();
            IEnumerable<SelectListItem> cats = new SelectList(lstCats, "CategorieID", "Nom");
            ViewBag.Categories = cats;
            return View();
        }

        // POST: Objets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ObjetID,nomObjet, description,CategorieID")] Objet objet)
        {
            if (ModelState.IsValid)
            {
                //unitOfWork.Repo<Objet>().context.Objets.Add(objet);                
                //unitOfWork.Repo<Objet>().context.SaveChanges();
                Objet a = new Objet { ObjetID = objet.ObjetID, nomObjet = objet.nomObjet, CategorieID = objet.CategorieID, description = objet.description};
                unitOfWork.Repo<Objet>().AddtoCurMembre(a);
                return RedirectToAction("Index");
            }

            return View(objet);
        }

        [Route("Edit")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Objet objet = unitOfWork.ObjetRepository.GetByID(id);
            if (objet == null)
            {
                return HttpNotFound();
            }
            return View(objet);
        }

        // POST: Objets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ObjetID,nomObjet")] Objet objet)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.ObjetRepository.Update(objet);
                unitOfWork.Save();
                return RedirectToAction("Index");
            }
            return View(objet);
        }

        [Route("Delete")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Objet objet = unitOfWork.ObjetRepository.GetByID(id);
            if (objet == null)
            {
                return HttpNotFound();
            }
            return View(objet);
        }

        // POST: Objets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Objet objet = unitOfWork.ObjetRepository.GetByID(id);
            unitOfWork.ObjetRepository.Delete(objet);
            unitOfWork.Save();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                unitOfWork.Dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult IndexEN()
        {
            Session["Culture"] = new CultureInfo("en");
            return RedirectToAction("Index");
        }

        public ActionResult IndexFR()
        {
            Session["Culture"] = new CultureInfo("fr");
            return RedirectToAction("Index");
        }

        public ActionResult IndexFRCA()
        {
            Session["Culture"] = new CultureInfo("fr-CA");
            return RedirectToAction("Index");
        }
    }
}
