using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Vroem.DATA;
using Vroem.MODELS;

namespace Vroem.UnitTests
{
    [TestClass]
    public class RegistreerSQLTests
    {
        [TestMethod]
        public void CheckEmailExists_Null_ReturnsTrue()
        {
            //Arrange
            var registreer = new RegistreerSQL();
            string email = null;
            //Act
            var returnvalue = registreer.CheckEmailExists(email);
            //Assert
            Assert.AreEqual(true, returnvalue);
        }
        
        [TestMethod]
        public void CheckEmailExists_BestaatNiet_ReturnsTrue()
        {
            //Arrange
            var registreer = new RegistreerSQL();
            string email = "koenr@gmail.com";
            //Act
            var returnvalue = registreer.CheckEmailExists(email);
            //Assert
            Assert.AreEqual(true, returnvalue);
        }
        
        [TestMethod]
        public void CheckEmailExists_Bestaat_ReturnsFalse()
        {
            //Arrange
            var registreer = new RegistreerSQL();
            string email = "koen@gmail.com";
            //Act
            var returnvalue = registreer.CheckEmailExists(email);
            //Assert
            Assert.AreEqual(false, returnvalue);
        }
        
        [TestMethod]
        public void CheckUsernameExists_Null_ReturnsTrue()
        {
            //Arrange
            var registreer = new RegistreerSQL();
            string gebruikersnaam = null;
            //Act
            var returnvalue = registreer.CheckUsernameExists(gebruikersnaam);
            //Assert
            Assert.AreEqual(true, returnvalue);
        }
        
        [TestMethod]
        public void CheckUsernameExists_BestaatNiet_ReturnsTrue()
        {
            //Arrange
            var registreer = new RegistreerSQL();
            string gebruikersnaam = "koen1234";
            //Act
            var returnvalue = registreer.CheckUsernameExists(gebruikersnaam);
            //Assert
            Assert.AreEqual(true, returnvalue);
        }
        
        [TestMethod]
        public void CheckUserNameExists_Bestaat_ReturnsFalse()
        {
            //Arrange
            var registreer = new RegistreerSQL();
            string username = "koen124";
            //Act
            var returnvalue = registreer.CheckUsernameExists(username);
            //Assert
            Assert.AreEqual(false, returnvalue);
        }
        
        [TestMethod]
        public void Registreer_Null_ReturnsFalse()
        {
            //Arrange
            var registreer = new RegistreerSQL();
            var user = new User { };
            //Act
            var returnvalue = registreer.Registreer(user);
            //Assert
            Assert.AreEqual(false, returnvalue);
        }
        
        [TestMethod]
        public void Registreer_EmailBestaatAl_ReturnsFalse()
        {
            //Arrange
            var registreer = new RegistreerSQL();
            var user = new User
            {
                Gebruikersnaam = "unit",
                Achternaam = "Test",
                Admin = 0,
                Email = "koen@gmail.com",
                Telefoonnummer = "0612344567",
                Wachtwoord = "Unit",
                Woonplaats = "Test",
                Voornaam = "Unit" 
            };
            //Act
            var returnvalue = registreer.Registreer(user);
            //Assert
            Assert.AreEqual(false, returnvalue);
        }
        
        [TestMethod]
        public void Registreer_GebruikersnaamBestaatAl_ReturnsFalse()
        {
            //Arrange
            var registreer = new RegistreerSQL();
            var user = new User
            {
                Gebruikersnaam = "koen124",
                Achternaam = "Test",
                Admin = 0,
                Email = "unit@test.com",
                Telefoonnummer = "0612344567",
                Wachtwoord = "Unit",
                Woonplaats = "Test",
                Voornaam = "Unit" 
            };
            //Act
            var returnvalue = registreer.Registreer(user);
            //Assert
            Assert.AreEqual(false, returnvalue);
        }
        
        [TestMethod]
        public void Registreer_NieuweGebruiker_ReturnsTrue()
        {
            //Arrange
            var registreer = new RegistreerSQL();
            Random rnd = new Random();
            var user = new User
            {
                Gebruikersnaam = $"unittest{rnd.Next(1,Int32.MaxValue)}",
                Achternaam = "Test",
                Admin = 0,
                Email = $"unit{rnd.Next(1,Int32.MaxValue)}@test.com",
                Telefoonnummer = "0612344567",
                Wachtwoord = "Unit",
                Woonplaats = "Test",
                Voornaam = "Unit" 
            };
            //Act
            var returnvalue = registreer.Registreer(user);
            //Assert
            Assert.AreEqual(true, returnvalue);
        }

        
    }
}