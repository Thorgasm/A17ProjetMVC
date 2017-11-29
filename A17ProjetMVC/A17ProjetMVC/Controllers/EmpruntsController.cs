using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using A17ProjetMVC.DAL;
using A17ProjetMVC.Models;

namespace A17ProjetMVC.Controllers
{
    [RoutePrefix("Emprunts")]
    public class EmpruntsController : Controller
    {
        private UnitOfWork unitOfWork = new UnitOfWork();

        [Route("Index")]
        public ActionResult Index()
        {
            return View(unitOfWork.UserRepository.Get());
        }

        [Route("Details")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Emprunt emprunt = unitOfWork.EmpruntRepository.GetByID(id);
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
            Emprunt emprunt = unitOfWork.EmpruntRepository.GetByID(id);
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
            Emprunt emprunt = unitOfWork.EmpruntRepository.GetByID(id);
            unitOfWork.EmpruntRepository.Delete(emprunt);
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
    }
}
