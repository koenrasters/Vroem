using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Vroem.DATA;
using Vroem.MODELS;

namespace Vroem.UnitTests
{
    [TestClass]
    public class UserSQLTests
    {
        [TestMethod]
        public void GetUser_IdBestaatNiet_IsNull()
        {
            //Arrange
            var userSql = new UserSQL();
            var id = 0;
            //Act
            var user = userSql.GetUser(id);
            //Assert
            Assert.IsNull(user);
        }
        
        [TestMethod]
        public void GetUser_IdBestaat_IsNotNull()
        {
            //Arrange
            var userSql = new UserSQL();
            var id = 1;
            //Act
            var user = userSql.GetUser(id);
            //Assert
            Assert.IsNotNull(user);
        }
        
        [TestMethod]
        public void GetUser_LoginNull_IsNull()
        {
            //Arrange
            var userSql = new UserSQL();
            string login = null;
            //Act
            var user = userSql.GetUser(login);
            //Assert
            Assert.IsNull(user);
        }
        
        [TestMethod]
        public void GetUser_UsernameBestaatNiet_IsNull()
        {
            //Arrange
            var userSql = new UserSQL();
            string login = "Piet";
            //Act
            var user = userSql.GetUser(login);
            //Assert
            Assert.IsNull(user);
        }
        
        [TestMethod]
        public void GetUser_EmailBestaat_IsNotNull()
        {
            //Arrange
            var userSql = new UserSQL();
            var email = "koen@gmail.com";
            //Act
            var user = userSql.GetUser(email);
            //Assert
            Assert.IsNotNull(user);
        }
        
        [TestMethod]
        public void GetUser_UsernameBestaat_IsNotNull()
        {
            //Arrange
            var userSql = new UserSQL();
            var username = "koen124";
            //Act
            var user = userSql.GetUser(username);
            //Assert
            Assert.IsNotNull(user);
        }
        
        [TestMethod]
        public void GetUsers_IsTrue()
        {
            //Arrange
            var userSql = new UserSQL();
            //Act
            var user = userSql.GetUsers();
            //Assert
            Assert.IsTrue(user.Any());
        }
        
        [TestMethod]
        public void EditAccount_Null_ReturnsFalse()
        {
            //Arrange
            var userSql = new UserSQL();
            User user = null;
            //Act
            var boolean = userSql.EditAccount(user);
            //Assert
            Assert.AreEqual(false,boolean);
        }
        
        [TestMethod]
        public void EditAccount_VerkeerdId_ReturnsFalse()
        {
            //Arrange
            var userSql = new UserSQL();
            var user = new User
            {
                Gebruikersnaam = "unittest",
                Achternaam = "Test",
                Admin = 0,
                Email = "unit@test.com",
                Telefoonnummer = "0612344567",
                Wachtwoord = "Unit",
                Woonplaats = "Test",
                Voornaam = "Unit" 
            };
            user.Id = 0;
            //Act
            var boolean = userSql.EditAccount(user);
            //Assert
            Assert.AreEqual(false,boolean);
        }
        
        [TestMethod]
        public void EditAccount_GoedeGegevens_ReturnsTrue()
        {
            //Arrange
            var userSql = new UserSQL();
            var user = new User
            {
                Gebruikersnaam = "unittest",
                Achternaam = "Test",
                Admin = 0,
                Email = "unit@test.com",
                Telefoonnummer = "0612344567",
                Wachtwoord = "Unit",
                Woonplaats = "Test",
                Voornaam = "Unit" 
            };
            user.Id = 11;
            //Act
            var boolean = userSql.EditAccount(user);
            //Assert
            Assert.AreEqual(true,boolean);
        }
        
        [TestMethod]
        public void EditPassword_Null_ReturnsFalse()
        {
            //Arrange
            var userSql = new UserSQL();
            var user = new User
            {
                
            };
            //Act
            var boolean = userSql.EditPassword(user);
            //Assert
            Assert.AreEqual(false,boolean);
        }
        
        [TestMethod]
        public void EditPassword_VerkeerdId_ReturnsFalse()
        {
            //Arrange
            var userSql = new UserSQL();
            var user = new User
            {
                Wachtwoord = "Unit"
            };
            user.Id = 0;
            //Act
            var boolean = userSql.EditPassword(user);
            //Assert
            Assert.AreEqual(false,boolean);
        }
        
        [TestMethod]
        public void EditPassword_GoedeGegevens_ReturnsTrue()
        {
            //Arrange
            var userSql = new UserSQL();
            var user = new User
            {
                Wachtwoord = "Unit"
            };
            user.Id = 11;
            //Act
            var boolean = userSql.EditPassword(user);
            //Assert
            Assert.AreEqual(true,boolean);
        }
        
        [TestMethod]
        public void BidOnCar_Null_ReturnsFalse()
        {
            //Arrange
            var userSql = new UserSQL();
            int userId = 0;
            int price = 0;
            int carId = 0;
            //Act
            var boolean = userSql.BidOnCar(userId,price,carId);
            //Assert
            Assert.AreEqual(false,boolean);
        }
        
        [TestMethod]
        public void BidOnCar_AutoIdKloptNiet_ReturnsFalse()
        {
            //Arrange
            var userSql = new UserSQL();
            int userId = 1;
            int price = 100;
            int carId = 0;
            //Act
            var boolean = userSql.BidOnCar(userId,price,carId);
            //Assert
            Assert.AreEqual(false,boolean);
        }
        
        [TestMethod]
        public void BidOnCar_GegevensKloppen_ReturnsTrue()
        {
            //Arrange
            var userSql = new UserSQL();
            int userId = 1;
            int price = 100;
            int carId = 1;
            //Act
            var boolean = userSql.BidOnCar(userId,price,carId);
            //Assert
            Assert.AreEqual(true,boolean);
        }

        [TestMethod] 
        public void GetBids_IdKloptNiet_IsFalse()
        {
            //Arrange
            var userSql = new UserSQL();
            int carId = 0;
            //Act
            var list = userSql.GetBids(carId);
            //Assert
            Assert.IsFalse(list.Any());
        }
        
        [TestMethod] 
        public void GetBids_AutoWaarNietOpGebodenWordt_IsFalse()
        {
            //Arrange
            var userSql = new UserSQL();
            int carId = 2;
            //Act
            var list = userSql.GetBids(carId);
            //Assert
            Assert.IsFalse(list.Any());
        }
        
        [TestMethod] 
        public void GetBids_IdKlopt_IsTrue()
        {
            //Arrange
            var userSql = new UserSQL();
            int carId = 1;
            //Act
            var list = userSql.GetBids(carId);
            //Assert
            Assert.IsTrue(list.Any());
        }
        
        
    }
}