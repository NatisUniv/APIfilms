using APIfilms.Models.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TP4_partie_1.Controllers;
using TP4_partie_1.Models.EntityFramework;

namespace TP4_partie_1.Controllers.Tests
{
    [TestClass]
    public class UtilisateursControllerTests
    {
        private UtilisateursController _controller;
        private FilmRatingsDBContext _context;

        [TestInitialize]
        public void Init()
        {
            var options = new DbContextOptionsBuilder<FilmRatingsDBContext>()
                .UseNpgsql("Host=localhost;Port=5432;Database=FilmsDB;Username=postgres;Password=postgres")
                .Options;

            _context = new FilmRatingsDBContext(options);
            _controller = new UtilisateursController(_context);
        }

        [TestMethod]
        public async Task GetUtilisateurs_ReturnsAllUtilisateurs()
        {
            var actionResult = await _controller.GetUtilisateurs();
            var result = actionResult.Value;

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count() > 0, "La liste des utilisateurs ne devrait pas être vide (si la BD est remplie).");

            Assert.AreEqual(_context.Utilisateurs.Count(), result.Count());
        }

        [TestMethod]
        public async Task GetUtilisateurById_ExistingId_ReturnsUtilisateur()
        {
            var userExpected = _context.Utilisateurs.First();

            var actionResult = await _controller.GetUtilisateurById(userExpected.UtilisateurId);
            var result = actionResult.Value;

            Assert.IsNotNull(result);
            Assert.AreEqual(userExpected.Nom, result.Nom);
            Assert.AreEqual(userExpected.Mail, result.Mail);
        }

        [TestMethod]
        public async Task GetUtilisateurById_NonExistingId_ReturnsNotFound()
        {
            int invalidId = 9999999;

            var actionResult = await _controller.GetUtilisateurById(invalidId);

            Assert.IsInstanceOfType(actionResult.Result, typeof(NotFoundResult));
        }

        [TestMethod]
        public async Task GetUtilisateurByEmail_ExistingEmail_ReturnsUtilisateur()
        {
            var userExpected = _context.Utilisateurs.First();

            var actionResult = await _controller.GetUtilisateurByEmail(userExpected.Mail);
            var result = actionResult.Value;

            Assert.IsNotNull(result);
            Assert.AreEqual(userExpected.UtilisateurId, result.UtilisateurId);
        }

        [TestMethod]
        public async Task GetUtilisateurByEmail_NonExistingEmail_ReturnsNotFound()
        {
            string invalidEmail = "inexistant@test.com";

            var actionResult = await _controller.GetUtilisateurByEmail(invalidEmail);

            Assert.IsInstanceOfType(actionResult.Result, typeof(NotFoundResult));
        }

        [TestMethod]
        public void PostUtilisateur_ModelValidated_CreationOK()
        {
            Random rnd = new Random();
            int chiffre = rnd.Next(1, 1000000000);

            Utilisateur userAtester = new Utilisateur()
            {
                Nom = "TESTER",
                Prenom = "Unit",
                Mobile = "0606060606",
                Mail = "testunit" + chiffre + "@gmail.com",
                Pwd = "Password123!",
                Rue = "Rue du Test",
                CodePostal = "75000",
                Ville = "TestCity",
                Pays = "France",
                Latitude = null,
                Longitude = null
            };

            var actionResult = _controller.PostUtilisateur(userAtester).Result;

            Assert.IsInstanceOfType(actionResult.Result, typeof(CreatedAtActionResult));

            Utilisateur userRecupere = _context.Utilisateurs
                .FirstOrDefault(u => u.Mail.ToUpper() == userAtester.Mail.ToUpper());

            Assert.IsNotNull(userRecupere, "L'utilisateur n'a pas été trouvé dans la BDD.");
            Assert.AreEqual(userAtester.Nom, userRecupere.Nom);

            _context.Utilisateurs.Remove(userRecupere);
            _context.SaveChanges();
        }

        [TestMethod]
        public async Task PostUtilisateur_InvalidModel_ReturnsBadRequest()
        {
            Utilisateur userInvalid = new Utilisateur()
            {
                Nom = "Invalide",
            };

            _controller.ModelState.AddModelError("Mail", "Required");
            _controller.ModelState.AddModelError("Pwd", "Required");

            var actionResult = await _controller.PostUtilisateur(userInvalid);

            Assert.IsInstanceOfType(actionResult.Result, typeof(BadRequestObjectResult));
        }

        [TestMethod]
        public async Task DeleteUtilisateur_ExistingId_DeletesUser()
        {
            Utilisateur userToDelete = new Utilisateur()
            {
                Nom = "TODELETE",
                Prenom = "Temp",
                Mail = "delete" + Guid.NewGuid() + "@test.com",
                Pwd = "Password123!"
            };

            _context.Utilisateurs.Add(userToDelete);
            await _context.SaveChangesAsync();
            int idToDelete = userToDelete.UtilisateurId;

            var actionResult = await _controller.DeleteUtilisateur(idToDelete);

            Assert.IsInstanceOfType(actionResult, typeof(NoContentResult));

            var deletedUser = await _context.Utilisateurs.FindAsync(idToDelete);
            Assert.IsNull(deletedUser, "L'utilisateur devrait avoir été supprimé de la base.");
        }
    }
}