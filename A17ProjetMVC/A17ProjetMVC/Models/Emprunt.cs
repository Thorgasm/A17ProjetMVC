using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace tp1_partie2.Models
{
    [Table("Emprunt")]
    public class Emprunt
    {
        [Key]
        public int EmpruntID { get; set; }
        [ForeignKey("Membre")]
        public int MembreID { get; set; }
        [ForeignKey("objet")]
        public int ObjetID { get; set; }
        [Column(TypeName = "date")]
        public DateTime dateDebut { get; set; }
        [Column(TypeName = "date")]
        public DateTime dateFin { get; set; }        

        public virtual Objet objet { get; set; }

        public Emprunt(int pMembreID, int pObjetID)
        {
            MembreID = pMembreID;
            ObjetID = pObjetID;
        }

        public Emprunt()
        {
            
        }
    }
}