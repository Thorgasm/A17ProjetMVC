using EntityFramework.MoqHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using A17ProjetMVC.Models;
//using A17ProjetMVC_Tests.MockData;

namespace A17ProjetMVC_Tests.Controllers
{
    [TestClass]
    class ObjetsControllerTest
    {
        Mock<ApplicationDbContext> mockContext;
        
        public void SetUp()
        {
            mockContext = EntityFrameworkMoqHelper.CreateMockForDbContext<ApplicationDbContext>();

            var categories = new List<Categorie>
            {
                new Categorie {CategorieID = 1, Nom = "Divers" },
                new Categorie {CategorieID = 2, Nom = "Decorations" },
                new Categorie {CategorieID = 3, Nom = "Sports" }
            }.AsQueryable();

            mockContext.Object.Categories.AddRange(categories);

            var user1 = new ApplicationUser() { Id = "1", UserName = "1000001", Email = "1000001", Adresse = "666", Nom = "1000001", Prenom = "User1", PhoneNumber = "5145145144" };
            var user2 = new ApplicationUser() { Id = "2", UserName = "1000002", Email = "1000002", Adresse = "666", Nom = "1000002", Prenom = "User2", PhoneNumber = "5145145155" };
            var user3 = new ApplicationUser() { Id = "3", UserName = "1000003", Email = "1000003", Adresse = "666", Nom = "1000003", Prenom = "User3", PhoneNumber = "5145145155" };
            var user4 = new ApplicationUser() { Id = "4", UserName = "1000004", Email = "1000004", Adresse = "666", Nom = "1000004", Prenom = "User4", PhoneNumber = "5145145155" };
            var user5 = new ApplicationUser() { Id = "5", UserName = "1000005", Email = "1000005", Adresse = "666", Nom = "1000005", Prenom = "User5", PhoneNumber = "5145145155" };

            mockContext.Object.Users.Add(user1);
            mockContext.Object.Users.Add(user2);
            mockContext.Object.Users.Add(user3);
            mockContext.Object.Users.Add(user4);
            mockContext.Object.Users.Add(user5);

            var objet1 = new Objet { CategorieID = 1, DatePublication = DateTime.Now, ObjetID = 1, Description = "un objet de test", NomObjet = "Objet1", estDisponible = true };
            var objet2 = new Objet { CategorieID = 1, DatePublication = DateTime.Now, ObjetID = 1, Description = "un objet de test", NomObjet = "Objet1", estDisponible = true };
            var objet3 = new Objet { CategorieID = 1, DatePublication = DateTime.Now, ObjetID = 1, Description = "un objet de test", NomObjet = "Objet1", estDisponible = true };
            var objet4 = new Objet { CategorieID = 1, DatePublication = DateTime.Now, ObjetID = 1, Description = "un objet de test", NomObjet = "Objet1", estDisponible = true };
            var objet5 = new Objet { CategorieID = 1, DatePublication = DateTime.Now, ObjetID = 1, Description = "un objet de test", NomObjet = "Objet1", estDisponible = true };
            var objet6 = new Objet { CategorieID = 1, DatePublication = DateTime.Now, ObjetID = 1, Description = "un objet de test", NomObjet = "Objet1", estDisponible = true };

            mockContext.Object.Users.Where(u => u.Id == user1.Id).FirstOrDefault().Objets.Add(objet1);
            mockContext.Object.Users.Where(u => u.Id == user1.Id).FirstOrDefault().Objets.Add(objet2);
            mockContext.Object.Users.Where(u => u.Id == user2.Id).FirstOrDefault().Objets.Add(objet3);
            mockContext.Object.Users.Where(u => u.Id == user3.Id).FirstOrDefault().Objets.Add(objet4);
            mockContext.Object.Users.Where(u => u.Id == user4.Id).FirstOrDefault().Objets.Add(objet5);
            mockContext.Object.Users.Where(u => u.Id == user5.Id).FirstOrDefault().Objets.Add(objet6);





        }
    }
}
