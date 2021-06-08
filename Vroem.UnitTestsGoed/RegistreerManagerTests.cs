using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Vroem.DAL;
using Vroem.LOGIC;
using Vroem.MODELS;

namespace Vroem.UnitTestsGoed
{
    [TestClass]
    public class RegistreerManagerTests
    {
        private readonly RegistreerManager registreer = new RegistreerManager(new DataAccess("mem"));
        [TestMethod] 
        public void Registreer_Null_ReturnsGebruikerNietAangemaakt()
        {
            //Arrange
            User gebruiker = null;
            //Act
            var statuscode = registreer.Registreer(gebruiker);
            //Assert
            Assert.AreEqual(StatusCodeEnum.GebruikerNietAangemaakt, statuscode);
        }
        
        [TestMethod] 
        public void Registreer_EmailBestaatAl_ReturnsGebruikerNietAangemaakt()
        {
            //Arrange
            User gebruiker = new User
            {
                Voornaam = "Unit",
                Achternaam = "Test",
                Email = "koen@gmail.com",
                Gebruikersnaam = "unit_test",
                Telefoonnummer = "",
                Wachtwoord = "unittest",
                Woonplaats = "unittest"
            };
            //Act
            var statuscode = registreer.Registreer(gebruiker);
            //Assert
            Assert.AreEqual(StatusCodeEnum.EmailBestaat, statuscode);
        }
        
        [TestMethod] 
        public void Registreer_UsernameBestaatAl_ReturnsGebruikerBestaat()
        {
            //Arrange
            User gebruiker = new User
            {
                Voornaam = "Unit",
                Achternaam = "Test",
                Email = "uni@test.com",
                Gebruikersnaam = "unit",
                Telefoonnummer = "",
                Wachtwoord = "unittest",
                Woonplaats = "unittest"
            };
            //Act
            var statuscode = registreer.Registreer(gebruiker);
            //Assert
            Assert.AreEqual(StatusCodeEnum.GebruikerBestaat, statuscode);
        }
        
        [TestMethod] 
        public void Registreer_BeideGegevensBestaan_ReturnsGebruikerNietAangemaakt()
        {
            //Arrange
            User gebruiker = new User
            {
                Voornaam = "Unit",
                Achternaam = "Test",
                Email = "unit@test.com",
                Gebruikersnaam = "unit",
                Telefoonnummer = "",
                Wachtwoord = "unittest",
                Woonplaats = "unittest"
            };
            //Act
            var statuscode = registreer.Registreer(gebruiker);
            //Assert
            Assert.AreEqual(StatusCodeEnum.GebruikerNietAangemaakt, statuscode);
        }
        
        [TestMethod] 
        public void Registreer_BeideGegevensBestaanNogNiet_ReturnsGebruikerAangemaakt()
        {
            //Arrange
            Random rnd = new Random();
            User gebruiker = new User
            {
                Voornaam = "Unit",
                Achternaam = "Test",
                Email = $"unit{rnd.Next(1,Int32.MaxValue)}@test.com",
                Gebruikersnaam = $"unit{rnd.Next(1,Int32.MaxValue)}",
                Telefoonnummer = "",
                Wachtwoord = "unittest",
                Woonplaats = "unittest"
            };
            //Act
            var statuscode = registreer.Registreer(gebruiker);
            //Assert
            Assert.AreEqual(StatusCodeEnum.GebruikerAangemaakt, statuscode);
        }
    }
}