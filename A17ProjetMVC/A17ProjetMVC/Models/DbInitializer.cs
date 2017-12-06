using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace A17ProjetMVC.Models
{
    public class DbInitializer : DropCreateDatabaseAlways<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            UserManager<ApplicationUser> UserManager = new ApplicationUserManager(new UserStore<ApplicationUser>(context));
            RoleManager<IdentityRole> RoleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            var user = new ApplicationUser { UserName = "1234567", Email = "admin@test.com" };
            user.Adresse = "666";
            user.Nom = "G";
            user.Prenom = "P";
            user.PhoneNumber = "4542345432";
            UserManager.Create(user, "pass");

            //var user2 = new ApplicationUser { UserName = "1234568", Email = "user@test.com" };
            //user2.Adresse = "666";
            //user2.Nom = "G";
            //user2.Prenom = "P";
            //user2.PhoneNumber = "4542345432";
            //UserManager.Create(user2, "pass");

            Categorie cat1 = new Categorie();
            cat1.CategorieID = 1;
            cat1.Nom = "Divers";

            Categorie cat2 = new Categorie();
            cat2.CategorieID = 2;
            cat2.Nom = "Utile";

            Categorie cat3 = new Categorie();
            cat3.CategorieID = 3;
            cat3.Nom = "Inutile";

            context.Categories.Add(cat1);
            context.Categories.Add(cat2);
            context.Categories.Add(cat3);

            context.SaveChanges();
        }
    }
}