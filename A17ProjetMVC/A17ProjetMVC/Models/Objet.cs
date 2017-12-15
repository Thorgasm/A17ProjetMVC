using A17ProjetMVC.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace A17ProjetMVC.Models
{
    [Table("Objet")]
    public class Objet
    {
        [Key]
        public int ObjetID { get; set; }
        
        [Display(Name = "ObjectName", ResourceType = typeof(Resources.site))]
        public string NomObjet { get; set; }

        [Display(Name = "objectDescription", ResourceType = typeof(Resources.site))]
        public string Description { get; set; }

        [Display(Name = "objectAvailable", ResourceType = typeof(Resources.site))]
        public bool estDisponible { get; set; }

        [ForeignKey("Categorie")]
        public int CategorieID { get; set; }

        [ForeignKey("User")]
        public string UserID { get; set; }

        [Display(Name = "objectPublicationDate", ResourceType = typeof(Resources.site))]
        [DataType(DataType.DateTime)]
        public DateTime DatePublication { get; set; }

        public virtual Categorie Categorie { get; set; }

        public virtual ApplicationUser User { get; set; }

    }
    
}