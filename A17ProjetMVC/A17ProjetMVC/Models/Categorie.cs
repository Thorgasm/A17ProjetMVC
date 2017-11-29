using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace A17ProjetMVC.Models
{
    [Table("Categorie")]
    public class Categorie
    {
        public int CategorieID { get; set; }

        [Display(Name = "Categorie")]
        public string Nom { get; set; }

        public virtual ICollection<Objet> Objets { get; set; }
    }
}