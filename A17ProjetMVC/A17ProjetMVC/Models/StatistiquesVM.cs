using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace A17ProjetMVC.Models
{
    public class StatistiquesVM
    {

        public IEnumerable<TopMemberVM> Top5MembreGenereuxMois { get; set; }
        public IEnumerable<TopMemberVM> Top5MembreGenereuxSemaine { get; set; }
        public IEnumerable<TopCategorieVM> Top5CategorieMoisBest { get; set; }
        public IEnumerable<TopCategorieVM> Top5CategorieSemaineBest { get; set; }
        public IEnumerable<TopCategorieVM> Top5CategorieMoisLeast { get; set; }
        public IEnumerable<TopCategorieVM> Top5CategorieSemaineLeast { get; set; }
        public IEnumerable<TopMembresAprecieVM> Top5MembresApreciesMois { get; set; }
        public IEnumerable<TopMembresAprecieVM> Top5MembresApreciesSemaine{ get; set; }


    }
}