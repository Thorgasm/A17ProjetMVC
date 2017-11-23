using A17ProjetMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace A17ProjetMVC.DAL
{
    public class UnitOfWork
    {
        private GenericRepository<ApplicationUser> userRepository;
        private GenericRepository<Emprunt> empruntRepository;
        private GenericRepository<Objet> objetRepository;
        private GenericRepository<Categorie> categorieRepository;


        private ApplicationDbContext context = new ApplicationDbContext();

        public GenericRepository<ApplicationUser> UserRepository
        {
            get
            {
                if (this.userRepository == null)
                {
                    this.userRepository = new GenericRepository<ApplicationUser>(context);
                }
                return userRepository;
            }
        }
        public GenericRepository<Emprunt> EmpruntRepository
        {
            get
            {
                if (this.empruntRepository == null)
                {
                    this.empruntRepository = new GenericRepository<Emprunt>(context);
                }
                return empruntRepository;
            }
        }
        public GenericRepository<Objet> ObjetRepository
        {
            get
            {
                if (this.objetRepository == null)
                {
                    this.objetRepository = new GenericRepository<Objet>(context);
                }
                return objetRepository;
            }
        }
        public GenericRepository<Categorie> CategorieRepository
        {
            get
            {
                if (this.categorieRepository == null)
                {
                    this.categorieRepository = new GenericRepository<Categorie>(context);
                }
                return categorieRepository;
            }
        }

        //-----------------------------------------------

        //public IEnumerable<Objet> GetObjetsDisponible()
        //{
        //    return ObjetRepository.Get().Where(e => e.EstDisponible).ToList();
        //}

        //public IEnumerable<Emprunt> GetEmpruntsDeMembre(int pMembreID)
        //{
        //    return EmpruntRepository.Get().Where(e => e.MembreID == pMembreID && !e.Objet.EstDisponible && e.DateFin > DateTime.Now).ToList();
        //}

        //public IEnumerable<Objet> GetTop5Objets()
        //{
        //    return ObjetRepository.Get().OrderByDescending(a => a.Emprunts.Count).Take(5).ToList();
        //}

        //public Emprunt Emprunter(int pMembreID, int pObjetID, int heures)
        //{
        //    DateTime debut = DateTime.Now;
        //    DateTime fin = DateTime.Now.AddHours(heures);

        //    Emprunt emprunt = new Emprunt();
        //    emprunt.DateDebut = debut;
        //    emprunt.DateFin = fin;
        //    emprunt.ObjetID = pObjetID;
        //    emprunt.MembreID = pMembreID;
        //    EmpruntRepository.Insert(emprunt);

        //    return emprunt;
        //}

        //-----------------------------------------------



        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}