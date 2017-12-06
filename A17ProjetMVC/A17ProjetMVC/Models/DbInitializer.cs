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
            UserManager<ApplicationUser> UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            RoleManager<IdentityRole> RoleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            ApplicationUser user_admin = new ApplicationUser();
            user_admin.Email = "admin@web.com";
            user_admin.UserName = "administrateur";
            IdentityResult result = UserManager.Create(user_admin, "12345");

            ApplicationUser user_member = new ApplicationUser();
            user_member.Email = "user@web.com";
            user_member.UserName = "1234567";
            IdentityResult result2 = UserManager.Create(user_member, "pass");

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