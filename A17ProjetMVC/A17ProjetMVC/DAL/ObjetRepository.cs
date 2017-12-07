using A17ProjetMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace A17ProjetMVC.DAL
{
    public enum TimeSpace
    {
        SEMAINE,
        MOIS
    }

    public static class ObjetRepository
    {

        public static List<Objet> GetAvailableObjets(this GenericRepository<Objet> repo)
        {
            List<Objet> lst = repo.context.Objets.Where(o => o.estDisponible).ToList();

            return lst;
        }

        public static List<Objet> GetMyObjects(this GenericRepository<Objet> repo, string UserID)
        {
            ApplicationUser mem = repo.context.Users.Where(m => m.Id == UserID).First();

            List<Objet> lst = mem.Objets.ToList();

            return lst;
        }

        public static bool AddtoCurMembre(this GenericRepository<Objet> repo, Objet ob, string UserID)
        {
            ApplicationUser a = repo.context.Users.Where(m => m.Id == UserID).First();

            ob.User = a;
            repo.Insert(ob);

            //a.Objets.Add(ob);
            repo.context.SaveChanges();
            
            return true;
        }

        public static List<Objet> GetObjetsByCat(this GenericRepository<Objet> repo, int pCatID)
        {
            List<Objet> lst = repo.context.Objets.Where(o => o.CategorieID == pCatID).ToList();

            return lst;
        }
        // je pense que l'objet le plus demandé est celui qui a le plus d'emprunts
        public static List<Objet> getTop5Objets(this GenericRepository<Objet> repo)
        {
            List<Emprunt> lst = new List<Emprunt>();
            foreach (ApplicationUser m in repo.context.Users)
            {
                lst.AddRange(m.Emprunts.ToList());
            }
            List<Objet> lstO = lst.Select(a => a.Objet).ToList();

            List<Objet> top = lstO.GroupBy(o => o.ObjetID).OrderByDescending(o => o.Count()).Select(g => new Objet { ObjetID = g.Key }).ToList();

            for (int i = 0; i < top.Count; i++)
            {
                top[i] = repo.context.Objets.Find(top[i].ObjetID);
            }

            return top;
        }

        public static List<TopMemberVM> getTopMembres(this GenericRepository<Objet> repo, TimeSpace pTimeSpace)
        {
            DateTime min = DateTime.Now;
            if (pTimeSpace == TimeSpace.MOIS)
            {
                min = min.AddDays(-30);
            }
            else if (pTimeSpace == TimeSpace.SEMAINE)
            {
                min = min.AddDays(-7);
            }
            List<TopMemberVM> lstO = repo.context.Users.Select(a => new TopMemberVM { User = a, ObjetCount = a.Objets.Where(b => b.DatePublication > min).Count() }).OrderByDescending(a => a.ObjetCount).Where(a => a.ObjetCount > 0).Take(5).ToList();

            return lstO;
        }

        public static List<TopCategorieVM> getTopCategories(this GenericRepository<Objet> repo, TimeSpace pTimeSpace, bool pPlus)
        {
            DateTime min = DateTime.Now;
            if (pTimeSpace == TimeSpace.MOIS)
            {
                min = min.AddDays(-30);
            }
            else if (pTimeSpace == TimeSpace.SEMAINE)
            {
                min = min.AddDays(-7);
            }
            List<TopCategorieVM> lstC = null;

            if (pPlus)
            {
                lstC = repo.context.Categories.Select(a => new TopCategorieVM { Categorie = a, Count = a.Objets.Where(b => b.DatePublication > min).Count() }).OrderByDescending(a => a.Count).Take(5).ToList();
            }
            else
            {
                lstC = repo.context.Categories.Select(a => new TopCategorieVM { Categorie = a, Count = a.Objets.Where(b => b.DatePublication > min).Count() }).OrderBy(a => a.Count).Take(5).ToList();
            }

            return lstC;
        }

        public static List<TopMembresAprecieVM> getTopMembresAprecies(this GenericRepository<Objet> repo, TimeSpace pTimeSpace)
        {
            DateTime min = DateTime.Now;
            if (pTimeSpace == TimeSpace.MOIS)
            {
                min.AddDays(-30);
            }
            else if (pTimeSpace == TimeSpace.SEMAINE)
            {
                min.AddDays(-7);
            }
            List<TopMembresAprecieVM> lstM = lstM = repo.context.Emprunts
                .GroupBy(u => u.User)
                .Select(u => new TopMembresAprecieVM { AverageNotes = u.Key.Emprunts.Where(e => e.DateFin > min).Average(av => av.NoteService), User = u.Key })
                .OrderByDescending(a => a.AverageNotes).Take(5)
                .ToList();
            


            return lstM;
        }
    }
}