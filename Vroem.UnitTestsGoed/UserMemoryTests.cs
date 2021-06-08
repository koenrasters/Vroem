using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Vroem.DATA;
using Vroem.MODELS;

namespace Vroem.UnitTestsGoed
{
    [TestClass]
    public class UserMemoryTests
    {
        private readonly UserMemory userMem = new UserMemory();
        
        [TestMethod]
        public void GetUser_IdBestaatNiet_ReturnsNull()
        {
            //Arrange
            int id = 0;
            //Act
            var user = userMem.GetUser(id);
            //Assert
            Assert.IsNull(user);
        }
        
        [TestMethod]
        public void GetUser_IdBestaat_ReturnsUser()
        {
            //Arrange
            int id = 1;
            //Act
            var user = userMem.GetUser(id);
            //Assert
            Assert.IsNotNull(user);
        }
        
        [TestMethod]
        public void GetUser_LoginNull_ReturnsNull()
        {
            //Arrange
            string login = null;
            //Act
            var user = userMem.GetUser(login);
            //Assert
            Assert.IsNull(user);
        }
        
        [TestMethod]
        public void GetUser_UsernameBestaatNiet_ReturnsNull()
        {
            //Arrange
            string login = "Piet";
            //Act
            var user = userMem.GetUser(login);
            //Assert
            Assert.IsNull(user);
        }
        
        [TestMethod]
        public void GetUser_EmailBestaat_ReturnsUser()
        {
            //Arrange
            var email = "unit@test.nl";
            //Act
            var user = userMem.GetUser(email);
            //Assert
            Assert.IsNotNull(user);
        }
        
        [TestMethod]
        public void GetUser_UsernameBestaat_ReturnsUser()
        {
            //Arrange
            var username = "unittest";
            //Act
            var user = userMem.GetUser(username);
            //Assert
            Assert.IsNotNull(user);
        }
        
        [TestMethod]
        public void GetUsers_ReturnsList()
        {
            //Arrange
            //Act
            var user = userMem.GetUsers();
            //Assert
            Assert.IsTrue(user.Any());
        }
        
        [TestMethod]
        public void EditAccount_Null_ReturnsFalse()
        {
            //Arrange
            User user = null;
            //Act
            var boolean = userMem.EditAccount(user);
            //Assert
            Assert.AreEqual(false,boolean);
        }
        
        [TestMethod]
        public void EditAccount_VerkeerdId_ReturnsFalse()
        {
            //Arrange
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
            var boolean = userMem.EditAccount(user);
            //Assert
            Assert.AreEqual(false,boolean);
        }
        
        [TestMethod]
        public void EditAccount_GoedeGegevens_ReturnsTrue()
        {
            //Arrange
            
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
            user.Id = 1;
            //Act
            var boolean = userMem.EditAccount(user);
            //Assert
            Assert.AreEqual(true,boolean);
        }
        
        [TestMethod]
        public void EditPassword_Null_ReturnsFalse()
        {
            //Arrange
            
            var user = new User
            {
                
            };
            //Act
            var boolean = userMem.EditPassword(user);
            //Assert
            Assert.AreEqual(false,boolean);
        }
        
        [TestMethod]
        public void EditPassword_VerkeerdId_ReturnsFalse()
        {
            //Arrange
            
            var user = new User
            {
                Wachtwoord = "Unit"
            };
            user.Id = 0;
            //Act
            var boolean = userMem.EditPassword(user);
            //Assert
            Assert.AreEqual(false,boolean);
        }
        
        [TestMethod]
        public void EditPassword_GoedeGegevens_ReturnsTrue()
        {
            //Arrange
            var user = new User
            {
                Wachtwoord = "Unit"
            };
            user.Id = 1;
            //Act
            var boolean = userMem.EditPassword(user);
            //Assert
            Assert.AreEqual(true,boolean);
        }
        
        [TestMethod]
        public void BidOnCar_Null_ReturnsFalse()
        {
            //Arrange
            int userId = 0;
            int price = 0;
            int carId = 0;
            //Act
            var boolean = userMem.BidOnCar(userId,price,carId);
            //Assert
            Assert.AreEqual(false,boolean);
        }
        
        [TestMethod]
        public void BidOnCar_AutoIdKloptNiet_ReturnsFalse()
        {
            //Arrange
            int userId = 1;
            int price = 100;
            int carId = 0;
            //Act
            var boolean = userMem.BidOnCar(userId,price,carId);
            //Assert
            Assert.AreEqual(false,boolean);
        }
        
        [TestMethod]
        public void BidOnCar_GegevensKloppen_ReturnsTrue()
        {
            //Arrange
            
            int userId = 1;
            int price = 100;
            int carId = 1;
            //Act
            var boolean = userMem.BidOnCar(userId,price,carId);
            //Assert
            Assert.AreEqual(true,boolean);
        }

        [TestMethod] 
        public void GetBids_IdKloptNiet_ReturnsEmptyList()
        {
            //Arrange
            int carId = 0;
            //Act
            var list = userMem.GetBids(carId);
            //Assert
            Assert.IsFalse(list.Any());
        }
        
        [TestMethod] 
        public void GetBids_AutoWaarNietOpGebodenWordt_ReturnsEmptyList()
        {
            //Arrange
            int carId = 2;
            //Act
            var list = userMem.GetBids(carId);
            //Assert
            Assert.IsFalse(list.Any());
        }
        
        [TestMethod] 
        public void GetBids_IdKlopt_ReturnsList()
        {
            //Arrange
            int carId = 1;
            //Act
            var list = userMem.GetBids(carId);
            //Assert
            Assert.IsTrue(list.Any());
        }
        
    }
}