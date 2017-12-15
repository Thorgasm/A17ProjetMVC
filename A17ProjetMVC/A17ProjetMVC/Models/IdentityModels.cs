using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using A17ProjetMVC.Resources;

namespace A17ProjetMVC.Models
{
    // Vous pouvez ajouter des données de profil pour l'utilisateur en ajoutant plus de propriétés à votre classe ApplicationUser ; consultez http://go.microsoft.com/fwlink/?LinkID=317594 pour en savoir davantage.
    public class ApplicationUser : IdentityUser
    {
        [Display(Name = "statLastName", ResourceType = typeof(Resources.site))]
        public string Nom { get; set; }

        [Display(Name = "statFirstName", ResourceType = typeof(Resources.site))]
        public string Prenom { get; set; }
        
        [Display(Name = "modelUserAddress", ResourceType = typeof(Resources.site))]
        public string Adresse { get; set; }

        [Display(Name = "modelUserTel", ResourceType = typeof(Resources.site))]
        [Phone]
        public override string PhoneNumber
        {
            get
            {
                return base.PhoneNumber;
            }

            set
            {
                base.PhoneNumber = value;
            }
        }

        [Display(Name = "statRegistrationNumber", ResourceType = typeof(Resources.site))]
        public override string UserName
        {
            get
            {
                return base.UserName;
            }

            set
            {
                base.UserName = value;
            }
        }

        public virtual List<Objet> Objets { get; set; }

        public virtual List<Emprunt> Emprunts { get; set; }


        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Notez qu'authenticationType doit correspondre à l'élément défini dans CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Ajouter les revendications personnalisées de l’utilisateur ici
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            //Database.SetInitializer(new DropCreateDatabaseIfModelChanges<ApplicationDbContext>());
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
        public virtual DbSet<Objet> Objets { get; set; }
        public virtual DbSet<Emprunt> Emprunts { get; set; }
        public virtual DbSet<Categorie> Categories { get; set; }
    }
}