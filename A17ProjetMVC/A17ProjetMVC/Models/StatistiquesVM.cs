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

    }
}