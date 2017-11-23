using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using tp1_partie2.DAL;
using tp1_partie2.Models;
using tp1_partie2.ViewModels;

namespace tp1_partie2.Controllers
{
    [RoutePrefix("Emprunts")]
    public class EmpruntsController : Controller
    {
        private UnitOfWork unitOfWork = new UnitOfWork();

        [Route("Index")]
        public ActionResult Index()
        {
            return View(unitOfWork.Repo<Membre>().GetByID(1).emprunt.ToList());
        }




        [Route("Details")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Emprunt emprunt = unitOfWork.Repo<Emprunt>().context.Emprunts.Find(id);
            if (emprunt == null)
            {
                return HttpNotFound();
            }
            return View(emprunt);
        }




        [Route("Delete")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Emprunt emprunt = unitOfWork.Repo<Emprunt>().context.Emprunts.Find(id);
            if (emprunt == null)
            {
                return HttpNotFound();
            }
            return View(emprunt);
        }

        // POST: Emprunts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Emprunt emprunt = unitOfWork.Repo<Emprunt>().context.Emprunts.Find(id);
            unitOfWork.Repo<Emprunt>().context.Emprunts.Remove(emprunt);
            unitOfWork.Repo<Emprunt>().context.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                unitOfWork.Repo<Emprunt>().context.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
