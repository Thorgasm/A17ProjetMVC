using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace A17ProjetMVC.Models
{
    public class DbInitializer : DropCreateDatabaseIfModelChanges<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            UserManager<ApplicationUser> UserManager = new ApplicationUserManager(new UserStore<ApplicationUser>(context));
            RoleManager<IdentityRole> RoleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            for(int i = 0; i < 10; i++)
            {
                string matricule = (1000000 + i) + "";

                var user = new ApplicationUser { UserName = matricule, Email = matricule + "@test.com" };
                user.Adresse = "666";
                user.Nom = "TestN"+ matricule;
                user.Prenom = "TestP"+ matricule;
                user.PhoneNumber = "4542345432";
                UserManager.Create(user, "Passw0rd!");
            }


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
            cat2.Nom = "Décoration";

            Categorie cat3 = new Categorie();
            cat3.CategorieID = 3;
            cat3.Nom = "Transport";

            Categorie cat4 = new Categorie();
            cat4.CategorieID = 4;
            cat4.Nom = "Jouet";

            Categorie cat5 = new Categorie();
            cat5.CategorieID = 5;
            cat5.Nom = "Jeu Vidéo";

            Categorie cat6 = new Categorie();
            cat6.CategorieID = 6;
            cat6.Nom = "Fourniture";

            Categorie cat7 = new Categorie();
            cat7.CategorieID = 7;
            cat7.Nom = "Outil";

            Categorie cat8 = new Categorie();
            cat8.CategorieID = 8;
            cat8.Nom = "Autre";

            context.Categories.Add(cat1);
            context.Categories.Add(cat2);
            context.Categories.Add(cat3);
            context.Categories.Add(cat4);
            context.Categories.Add(cat5);
            context.Categories.Add(cat6);
            context.Categories.Add(cat7);
            context.Categories.Add(cat8);

            context.SaveChanges();
        }
    }
}