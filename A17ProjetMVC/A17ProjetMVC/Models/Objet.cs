using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace tp1_partie2.Models
{
    [Table("Objet")]
    public class Objet
    {
        [Key]
        public int ObjetID { get; set; }
        
        public string nomObjet { get; set; }

        public string description { get; set; }

        [ForeignKey("Categorie")]
        public int CategorieID { get; set; }

        
        public int MembreID { get; set; }

        public virtual Categorie Categorie { get; set; }
        

    }
    
}