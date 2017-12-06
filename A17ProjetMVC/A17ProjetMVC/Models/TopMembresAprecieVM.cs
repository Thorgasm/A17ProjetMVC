using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace A17ProjetMVC.Models
{
    public class TopMembresAprecieVM
    {
        public ApplicationUser User { get; set; }
        public Double AverageNotes { get; set; }
    }
}