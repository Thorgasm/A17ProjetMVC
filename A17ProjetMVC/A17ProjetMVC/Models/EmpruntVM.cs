using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace A17ProjetMVC.Models
{
    public class EmpruntVM
    {

        public int ObjetID;

        [Display(Name ="borrowVMDayNumber", ResourceType = typeof(Resources.site))]
        public int NbJours;

    }
}