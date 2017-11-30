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

        [Column(TypeName = "date")]
        public DateTime DateDebut { get; set; }

        [Column(TypeName = "date")]
        public DateTime DateFin { get; set; }     
        
        [Range(1,5)]
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