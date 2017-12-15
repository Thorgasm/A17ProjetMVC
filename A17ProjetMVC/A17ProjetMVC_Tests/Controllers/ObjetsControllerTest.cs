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

            var objets = new List<Objet>
            {
            new Objet { CategorieID = 1, DatePublication = DateTime.Now, ObjetID = 1, Description = "un objet de test", NomObjet = "Objet1", estDisponible = true, UserID = "1" },
            new Objet { CategorieID = 1, DatePublication = DateTime.Now, ObjetID = 2, Description = "un objet de test", NomObjet = "Objet2", estDisponible = false, UserID = "1" },
            new Objet { CategorieID = 2, DatePublication = DateTime.Now, ObjetID = 3, Description = "un objet de test", NomObjet = "Objet3", estDisponible = true, UserID = "1" },
            new Objet { CategorieID = 2, DatePublication = DateTime.Now, ObjetID = 4, Description = "un objet de test", NomObjet = "Objet4", estDisponible = false, UserID = "2" },
            new Objet { CategorieID = 2, DatePublication = DateTime.Now, ObjetID = 5, Description = "un objet de test", NomObjet = "Objet5", estDisponible = true, UserID = "2" },
            new Objet { CategorieID = 3, DatePublication = DateTime.Now, ObjetID = 6, Description = "un objet de test", NomObjet = "Objet6", estDisponible = false, UserID = "3" }
            }.AsQueryable();

            mockContext.Object.Objets.AddRange(objets);

            var users = new List<ApplicationUser>();


            users.Add(new ApplicationUser() { Id = "1", UserName = "1000001", Email = "1000001", Adresse = "666", Nom = "1000001", Prenom = "User1", PhoneNumber = "5145145144", Objets = new List<Objet>() { objets.ElementAt(0), objets.ElementAt(1), objets.ElementAt(2) }, Emprunts = new List<Emprunt>() });
            users.Add(new ApplicationUser() { Id = "2", UserName = "1000002", Email = "1000002", Adresse = "666", Nom = "1000002", Prenom = "User2", PhoneNumber = "5145145155", Objets = new List<Objet>() { objets.ElementAt(3), objets.ElementAt(4) }, Emprunts = new List<Emprunt>() });
            users.Add(new ApplicationUser() { Id = "3", UserName = "1000003", Email = "1000003", Adresse = "666", Nom = "1000003", Prenom = "User3", PhoneNumber = "5145145155", Objets = new List<Objet>(), Emprunts = new List<Emprunt>() });
            users.Add(new ApplicationUser() { Id = "4", UserName = "1000004", Email = "1000004", Adresse = "666", Nom = "1000004", Prenom = "User4", PhoneNumber = "5145145155", Objets = new List<Objet>(), Emprunts = new List<Emprunt>() });
            users.Add(new ApplicationUser() { Id = "5", UserName = "1000005", Email = "1000005", Adresse = "666", Nom = "1000005", Prenom = "User5", PhoneNumber = "5145145155", Objets = new List<Objet>() { objets.ElementAt(5) }, Emprunts = new List<Emprunt>() });

            var mockSetUsers = DbSetMocking.CreateMockSet<ApplicationUser>(users);

            mockContext.Setup(c => c.Users).Returns(mockSetUsers.Object);
            

            var categories = new List<Categorie>
            {
                new Categorie {CategorieID = 1, Nom = "Divers" , Objets = new List<Objet>() { objets.ElementAt(0), objets.ElementAt(1) } },
                new Categorie {CategorieID = 2, Nom = "Decorations", Objets = new List<Objet>() {  objets.ElementAt(2), objets.ElementAt(3), objets.ElementAt(4) } },
                new Categorie {CategorieID = 3, Nom = "Sports", Objets = new List<Objet>() {  objets.ElementAt(5)} }
            }.AsQueryable();

            mockContext.Object.Categories.AddRange(categories);


        }

        
        [TestMethod]
        public void TestTopCategoriesPlus()
        {
            SetUp();

            GenericRepository<Objet> a = new GenericRepository<Objet>(mockContext.Object);

            var lst = a.getTopCategories(TimeSpace.SEMAINE,true);

            Assert.AreEqual(lst[0].Count, 3);
            Assert.AreEqual(lst[0].Categorie.Nom, "Decorations");

            Assert.AreEqual(lst[1].Count, 2);
            Assert.AreEqual(lst[1].Categorie.Nom, "Divers");

            Assert.AreEqual(lst[2].Count, 1);
            Assert.AreEqual(lst[2].Categorie.Nom, "Sports");


        }

        [TestMethod]
        public void TestTopCategoriesMoins()
        {
            SetUp();

            GenericRepository<Objet> a = new GenericRepository<Objet>(mockContext.Object);

            var lst = a.getTopCategories(TimeSpace.SEMAINE, false);

            Assert.AreEqual(lst[2].Count, 3);
            Assert.AreEqual(lst[2].Categorie.Nom, "Decorations");

            Assert.AreEqual(lst[1].Count, 2);
            Assert.AreEqual(lst[1].Categorie.Nom, "Divers");

            Assert.AreEqual(lst[0].Count, 1);
            Assert.AreEqual(lst[0].Categorie.Nom, "Sports");


        }

        [TestMethod]
        public void TestGetAvailableObjets()
        {
            SetUp();

            GenericRepository<Objet> a = new GenericRepository<Objet>(mockContext.Object);

            var lst = a.GetAvailableObjets();

            Assert.AreEqual(lst.First(x => x.ObjetID == 1).ObjetID, 1);

            Assert.AreEqual(lst.First(x => x.ObjetID == 3).ObjetID, 3);

            Assert.AreEqual(lst.First(x => x.ObjetID == 5).ObjetID, 5);

        }
        [TestMethod]
        public void TestGetObjetsByCat()
        {
            SetUp();

            GenericRepository<Objet> a = new GenericRepository<Objet>(mockContext.Object);

            var lst = a.GetObjetsByCat(1);

            Assert.AreEqual(lst[0].ObjetID, 1);

            Assert.AreEqual(lst[1].ObjetID, 2);

            Assert.AreEqual(lst.Count, 2);

        }

        //test fonctionnel mais MOCKCONTEXT.OBJECTS.USERS IS NULL
        [TestMethod]
        public void TestTop5MembreApreciesSemaine()
        {
            SetUp();
            var emprunts = new List<Emprunt>
            {
                new Emprunt { ObjetID = 1, UserID = "1", NoteService = 1, DateFin = DateTime.Now },
                new Emprunt { ObjetID = 2, UserID = "1", NoteService = 5, DateFin = DateTime.Now },
                new Emprunt { ObjetID = 3, UserID = "1", NoteService = 5, DateFin = DateTime.Now.AddMonths(-1) }
            }.AsQueryable();


            mockContext.Object.Emprunts.AddRange(emprunts);

            mockContext.Object.Users.Where(u => u.Id == "1").First().Emprunts.AddRange(emprunts);

            GenericRepository<Objet> a = new GenericRepository<Objet>(mockContext.Object);

            var lst = a.getTopMembresAprecies(TimeSpace.SEMAINE);

            Assert.AreEqual(2, lst.Count);

            Assert.AreEqual(3, lst.First().AverageNotes);

        }

        //test fonctionnel mais MOCKCONTEXT.OBJECTS.USERS IS NULL
        [TestMethod]
        public void TestGetMembresGenereux()
        {
            SetUp();

            GenericRepository<Objet> a = new GenericRepository<Objet>(mockContext.Object);

            var lst = a.getTopMembres(TimeSpace.SEMAINE);

            Assert.AreEqual(lst[0].User.Id, "1");

            Assert.AreEqual(lst[1].User.Id, "2");

            Assert.AreEqual(lst[2].User.Id, "3");

        }
    }
}
