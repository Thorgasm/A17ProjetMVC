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
            List<int> lstObjets = repo.context.Emprunts.Select(e => e.ObjetID).ToList();

            List<Objet> lst = repo.context.Objets.Where(o => !lstObjets.Contains(o.ObjetID)).ToList();

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
                min.AddDays(-30);
            }
            else if (pTimeSpace == TimeSpace.SEMAINE)
            {
                min.AddDays(-7);
            }
            List<TopMemberVM> lstO = repo.context.Users.Select(a => new TopMemberVM { User = a, ObjetCount = a.Objets.Count() }).OrderByDescending(a => a.ObjetCount).Take(5).ToList();

            return lstO;
        }

    }
}