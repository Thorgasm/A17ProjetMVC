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
using Microsoft.AspNet.Identity;

namespace A17ProjetMVC.Controllers
{
    [RoutePrefix("Emprunts")]
    [Authorize]
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

        [Route("MyLoans")]
        public ActionResult MesEmprunts()
        {
            var userID = User.Identity.GetUserId();

            var result = unitOfWork.EmpruntRepository.Get().Where(m => m.UserID == userID).ToList();

            return View("MesEmprunts", result);
        }

        public ActionResult Remettre(int? id)
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
            emprunt.DateFin = DateTime.Now;
            unitOfWork.Save();

            return View("EmpruntNote", emprunt);
        }

        [HttpPost, ActionName("Remettre")]
        [ValidateAntiForgeryToken]
        public ActionResult RemettreConfirmed(int id, FormCollection form)
        {
            Emprunt emprunt = unitOfWork.EmpruntRepository.GetByID(id);
            emprunt.NoteService = int.Parse(form["NoteService"].ToString());
            unitOfWork.Save();

            return RedirectToAction("MesEmprunts");
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
