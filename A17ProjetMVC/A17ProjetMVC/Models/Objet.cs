using A17ProjetMVC.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using tp1_partie2.Properties;

namespace tp1_partie2.Models
{
    [Table("Objet")]
    public class Objet
    {
        [Key]
        public int ObjetID { get; set; }
        [Display(Name = "Name", ResourceType = typeof(Resources.Models.Objet))]
        public string nomObjet { get; set; }

        public string description { get; set; }

        [ForeignKey("Categorie")]
        public int CategorieID { get; set; }

        [ForeignKey("User")]
        public int UserID { get; set; }

        public virtual Categorie Categorie { get; set; }

        public virtual ApplicationUser User { get; set; }

    }
    
}