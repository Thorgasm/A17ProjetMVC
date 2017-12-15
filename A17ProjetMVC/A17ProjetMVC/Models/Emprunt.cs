using A17ProjetMVC.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace A17ProjetMVC.Models
{
    [Table("Emprunt")]
    public class Emprunt
    {
        [Key]
        public int EmpruntID { get; set; }

        [ForeignKey("User")]
        public string UserID { get; set; }

        [ForeignKey("Objet")]
        public int ObjetID { get; set; }

        [Display(Name ="borrowStartDate",ResourceType = typeof(Resources.site))]
        [Column(TypeName = "date")]
        public DateTime DateDebut { get; set; }

        [Display(Name ="borrowEndDate", ResourceType = typeof(Resources.site))]
        [Column(TypeName = "date")]
        public DateTime DateFin { get; set; }

        [Display(Name ="borrowIsDelivered", ResourceType = typeof(Resources.site))]
        public Boolean EstRemis { get; set; }

        [Display(Name ="borrowServiceRating", ResourceType = typeof(Resources.site))]
        [Range(0,5)]
        public int NoteService { get; set; }   

        public virtual ApplicationUser User { get; set; }

        public virtual Objet Objet { get; set; }

        public Emprunt(string pUserID, int pObjetID)
        {
            UserID = pUserID;
            ObjetID = pObjetID;
        }

        public Emprunt()
        {
            
        }
    }
}