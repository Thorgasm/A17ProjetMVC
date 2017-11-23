using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace tp1_partie2.Models
{
    [Table("Categorie")]
    public class Categorie
    {
        public int CategorieID { get; set; }

        [Display(Name = "Name", ResourceType = typeof(Resources.Models.Categorie))]
        public string Nom { get; set; }

        public virtual ICollection<Objet> Objets { get; set; }
    }
}