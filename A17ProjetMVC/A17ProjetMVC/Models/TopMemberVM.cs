using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace A17ProjetMVC.Models
{
    public class TopMemberVM
    {
        public ApplicationUser User { get; set; }
        public int ObjetCount { get; set; }
    }
}