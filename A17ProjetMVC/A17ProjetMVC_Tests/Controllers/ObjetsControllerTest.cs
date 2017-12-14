//using EntityFramework.MoqHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using A17ProjetMVC.Models;
using A17ProjetMVC.Controllers;
using A17ProjetMVC.DAL;
using System.Data.Entity;
using A17ProjetMVC_Tests.MockData;
using Microsoft.AspNet.Identity.EntityFramework;
using A17ProjetMVC;
using Microsoft.AspNet.Identity;

namespace A17ProjetMVC_Tests.Controllers
{
    [TestClass]
    public class ObjetsControllerTest
    {
        Mock<ApplicationDbContext> mockContext;


        public async void SetUp()
        {

            mockContext = EntityFrameworkMockHelper.GetMockContext<ApplicationDbContext>();       

            var users = new List<ApplicationUser>();


            users.Add(new ApplicationUser() { Id = "1", UserName = "1000001", Email = "1000001", Adresse = "666", Nom = "1000001", Prenom = "User1", PhoneNumber = "5145145144", Objets = new List<Objet>(), Emprunts = new List<Emprunt>() });
            users.Add(new ApplicationUser() { Id = "2", UserName = "1000002", Email = "1000002", Adresse = "666", Nom = "1000002", Prenom = "User2", PhoneNumber = "5145145155", Objets = new List<Objet>(), Emprunts = new List<Emprunt>() });
            users.Add(new ApplicationUser() { Id = "3", UserName = "1000003", Email = "1000003", Adresse = "666", Nom = "1000003", Prenom = "User3", PhoneNumber = "5145145155", Objets = new List<Objet>(), Emprunts = new List<Emprunt>() });
            users.Add(new ApplicationUser() { Id = "4", UserName = "1000004", Email = "1000004", Adresse = "666", Nom = "1000004", Prenom = "User4", PhoneNumber = "5145145155", Objets = new List<Objet>(), Emprunts = new List<Emprunt>() });
            users.Add(new ApplicationUser() { Id = "5", UserName = "1000005", Email = "1000005", Adresse = "666", Nom = "1000005", Prenom = "User5", PhoneNumber = "5145145155", Objets = new List<Objet>(), Emprunts = new List<Emprunt>() });

            var mockSetUsers = DbSetMocking.CreateMockSet<ApplicationUser>(users);

            mockContext.Setup(c => c.Users).Returns(mockSetUsers.Object);

            var categories = new List<Categorie>
            {
                new Categorie {CategorieID = 1, Nom = "Divers" },
                new Categorie {CategorieID = 2, Nom = "Decorations" },
                new Categorie {CategorieID = 3, Nom = "Sports" }
            }.AsQueryable();

            mockContext.Object.Categories.AddRange(categories);


            /*mockContext.Object.Users.Add(user1);
            mockContext.Object.Users.Add(user2);
            mockContext.Object.Users.Add(user3);
            mockContext.Object.Users.Add(user4);
            mockContext.Object.Users.Add(user5);*/

            var objet1 = new Objet { CategorieID = 1, DatePublication = DateTime.Now, ObjetID = 1, Description = "un objet de test", NomObjet = "Objet1", estDisponible = true };
            var objet2 = new Objet { CategorieID = 1, DatePublication = DateTime.Now, ObjetID = 1, Description = "un objet de test", NomObjet = "Objet1", estDisponible = true };
            var objet3 = new Objet { CategorieID = 1, DatePublication = DateTime.Now, ObjetID = 1, Description = "un objet de test", NomObjet = "Objet1", estDisponible = true };
            var objet4 = new Objet { CategorieID = 1, DatePublication = DateTime.Now, ObjetID = 1, Description = "un objet de test", NomObjet = "Objet1", estDisponible = true };
            var objet5 = new Objet { CategorieID = 1, DatePublication = DateTime.Now, ObjetID = 1, Description = "un objet de test", NomObjet = "Objet1", estDisponible = true };
            var objet6 = new Objet { CategorieID = 1, DatePublication = DateTime.Now, ObjetID = 1, Description = "un objet de test", NomObjet = "Objet1", estDisponible = true };

            mockContext.Object.Users.ElementAt(0).Objets.Add(objet1);
            mockContext.Object.Users.ElementAt(0).Objets.Add(objet2);
            mockContext.Object.Users.ElementAt(1).Objets.Add(objet3);
            mockContext.Object.Users.ElementAt(2).Objets.Add(objet4);
            mockContext.Object.Users.ElementAt(3).Objets.Add(objet5);
            mockContext.Object.Users.ElementAt(4).Objets.Add(objet6);

            /*var emprunt1 = new Emprunt { ObjetID = 1, UserID = "1", NoteService = 1, DateFin = DateTime.Now };
            var emprunt2 = new Emprunt { ObjetID = 1, UserID = "1", NoteService = 5, DateFin = DateTime.Now };


            mockContext.Object.Emprunts.Add(emprunt1);
            mockContext.Object.Emprunts.Add(emprunt2);*/


        }
        [TestMethod]
        public void Top5MembreApreciesSemaine()
        {
            SetUp();
            var emprunt1 = new Emprunt { ObjetID = 1, UserID = "1", NoteService = 1, DateFin = DateTime.Now };
            var emprunt2 = new Emprunt { ObjetID = 2, UserID = "1", NoteService = 5, DateFin = DateTime.Now };
            var emprunt3 = new Emprunt { ObjetID = 3, UserID = "1", NoteService = 5, DateFin = DateTime.Now.AddMonths(-1) };            


            mockContext.Object.Emprunts.Add(emprunt1);
            mockContext.Object.Emprunts.Add(emprunt2);
            mockContext.Object.Emprunts.Add(emprunt3);

            List<ApplicationUser> test = mockContext.Object.Users.ToList();
            List<Objet> obj = mockContext.Object.Objets.ToList();
            List<Emprunt> em = mockContext.Object.Emprunts.ToList();
            List<Categorie> cat = mockContext.Object.Categories.ToList();
            mockContext.Object.SaveChanges();

            GenericRepository<Objet> a = new GenericRepository<Objet>(mockContext.Object);

            var lst = a.getTopMembresAprecies(TimeSpace.SEMAINE);

            Assert.AreEqual(1, lst.Count);
            

        }
    }
}
